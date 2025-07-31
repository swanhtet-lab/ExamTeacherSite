document.addEventListener("DOMContentLoaded", () => {

    const subjectList = document.getElementById("subjectList");

    const selectedDept = sessionStorage.getItem("selectedDepartment");
    const teacherName = sessionStorage.getItem("teacherName");
    const teacherYear = sessionStorage.getItem("year");
    const teacherClass = sessionStorage.getItem("class1");
    const headerText = document.getElementById("headerText");


    const img = document.getElementById("mybtn");
    const modal = document.getElementById("myModal");
    const modalbody = document.getElementById("modaltext");

    if (selectedDept) {
        headerText.textContent = `Department: ${selectedDept}`;
    } else {
        headerText.textContent = "No department selected";
    }

    img.onclick = function () {
        modal.style.display = "block";
        modalbody.textContent = `Name :${teacherName} Year : ${teacherClass}`
    }


    if (!selectedDept) {
        alert("No department selected.");
        window.location.href = "login.html";
        return;
    }

    const apiUrl = `https://localhost:7104/api/Department/${selectedDept}`;

    fetch(apiUrl)
        .then(res => {
            if (!res.ok) {
                throw new Error("Department not found.");
            }
            return res.json();
        })
        .then(data => {
            subjectList.innerHTML = "";

            if (!data.classes || data.classes.length === 0) {
                subjectList.innerHTML = "<p class='text-warning'>No classes or subjects found.</p>";
                return;
            }

            // Flatten subjects from all classes
            let allSubjects = [];
            data.classes.forEach(cls => {
                if (cls.subjects) {
                    allSubjects = allSubjects.concat(cls.subjects);
                }
            });

            if (allSubjects.length === 0) {
                subjectList.innerHTML = "<p class='text-warning'>No subjects available in this department.</p>";
                return;
            }

            allSubjects.forEach(subject => {
                const row = document.createElement("div");
                row.className = "subject-card d-flex align-items-center gap-3 p-3 mb-3 border rounded shadow-sm bg-light flex-wrap";

                // Subject input
                const input = document.createElement("input");
                input.className = "form-control flex-grow-1";
                input.value = subject.subject1;
                input.disabled = true;
                input.style.borderRadius = "15px";

                // Create static type badges
                const types = ["True or False","Multiple Choice","Blank", "Short Notes"];
                const typesWrapper = document.createElement("div");
                typesWrapper.className = "d-flex gap-2 flex-wrap";

                types.forEach(type => {
                    const typeBadge = document.createElement("span");
                    typeBadge.textContent = type;
                    typeBadge.className = "px-3 py-2 rounded text-white";

                    
                    const isAvailable = subject.availableTypes && subject.availableTypes.includes(type.toLowerCase());

                    if (isAvailable) {
                        typeBadge.classList.add("bg-success");
                    } else {
                        typeBadge.classList.add("bg-secondary");
                    }

                    typesWrapper.appendChild(typeBadge);
                });

                // Status button
                const btn = document.createElement("button");
                btn.textContent = subject.status;
                btn.className = "btn px-4 py-2 rounded";
                btn.classList.add(subject.status.toLowerCase() === "available" ? "btn-success" : "btn-danger");

                // Append everything
                row.appendChild(input);
                row.appendChild(typesWrapper);
                row.appendChild(btn);
                subjectList.appendChild(row);

                
            
                btn.onclick = () => {
                    if (subject.status.toLowerCase() === "available") {

                        sessionStorage.setItem("subjectId", subject.subjectId); 
                        sessionStorage.setItem("subjectName", subject.subject1);
                        sessionStorage.setItem("subjectStatus", subject.status);
                        alert("This subject is already available.");


                    } else {
                        alert("Go to Add Page")
                        sessionStorage.setItem("subjectId", subject.subjectId); 
                        sessionStorage.setItem("subjectName", subject.subject1);
                        sessionStorage.setItem("subjectStatus", subject.status);
                        window.location.href = "teacheraddQA.html";
                    }
                };
            });
        })
        .catch(err => {
            console.error("Error fetching subjects:", err);
            subjectList.innerHTML = "<p class='text-danger'>Failed to load subject data.</p>";
        });
});