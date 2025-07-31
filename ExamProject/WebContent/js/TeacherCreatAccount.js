document.addEventListener("DOMContentLoaded", () => {
    const Deptdropdown = document.getElementById("departmentDropdown");
    const subjectDropdown = document.getElementById("tsubject");
    const teacherName = document.getElementById("tname");
    const teacherPhone = document.getElementById("tph");
    const teacherEmail = document.getElementById("taemail");
    const teacherPosition = document.getElementById("tposition");
    const teacherCurrentClass = document.getElementById("tclass");
    const teacherCurrentYear = document.getElementById("tyear");
    const teacherPassword = document.getElementById("tpasword");
    const submitbtn = document.getElementById("submit");

    const departmentApi = "https://localhost:7104/api/Department";
    const teacherPostApi = "https://localhost:7104/api/Teacher";

    let departmentsData = [];

    // Load departments with classes and subjects
    fetch(departmentApi)
        .then(response => response.json())
        .then(data => {
            departmentsData = data;
            Deptdropdown.innerHTML = "<option disabled selected>Select Department</option>";
            data.forEach(dept => {
                const option = document.createElement("option");
                option.value = dept.departmentId;
                option.textContent = dept.department1;
                Deptdropdown.appendChild(option);
            });
        })
        .catch(error => {
            console.error("Error fetching departments:", error);
            Deptdropdown.innerHTML = `<option disabled>Error loading</option>`;
        });


    Deptdropdown.addEventListener("change", function () {
        const selectedDeptId = parseInt(this.value);
        const selectedDept = departmentsData.find(d => d.departmentId === selectedDeptId);

        if (!selectedDept || !selectedDept.classes) return;

        const allSubjects = selectedDept.classes.flatMap(cls => cls.subjects || []);

        

        // Optional: Remove duplicates
        const uniqueSubjects = Array.from(
            new Map(availableSubjects.map(sub => [sub.subjectId, sub])).values()
        );

        subjectDropdown.innerHTML = "<option disabled selected>Select Subject</option>";
        uniqueSubjects.forEach(subject => {
            const option = document.createElement("option");
            option.value = subject.subjectId;
            option.textContent = subject.subject1;
            subjectDropdown.appendChild(option);
        });
    });

    // Submit teacher form
    submitbtn.addEventListener("click", function (event) {
        event.preventDefault();

        const teacherData = {
            teacherName: teacherName.value,
            teacherEmail: teacherEmail.value,
            teacherPhone: teacherPhone.value,
            position: teacherPosition.value,
            teacherPassword: teacherPassword.value,
            departmentId: parseInt(Deptdropdown.value),
            subjectId: parseInt(subjectDropdown.value),
            currentClass: teacherCurrentClass.value,
            currentYear: teacherCurrentYear.value
        };

        const errors = [];

        if (!teacherData.teacherName) errors.push("Name is required.");
        if (!teacherData.teacherEmail || !teacherData.teacherEmail.includes("@")) errors.push("Valid email is required.");
        if (!teacherData.teacherPhone || teacherData.teacherPhone.length < 7) errors.push("Valid phone number is required.");
        if (!teacherData.position) errors.push("Position is required.");
        if (!teacherData.teacherPassword || teacherData.teacherPassword.length < 4) errors.push("Password must be at least 4 characters.");
        if (isNaN(teacherData.departmentId)) errors.push("Please select a department.");
        if (isNaN(teacherData.subjectId)) errors.push("Please select a subject.");
        if (!teacherData.currentClass) errors.push("Current class is required.");
        if (!teacherData.currentYear) errors.push("Current year is required.");

        if (errors.length > 0) {
            alert("Please fix the following:\n\n" + errors.join("\n"));
            return;
        }


        fetch(teacherPostApi, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(teacherData)
        })
            .then(response => {
                if (!response.ok) throw new Error("Failed to create teacher");
                return response.json();
            })
            .then(data => {
                alert("Teacher registered successfully!");
                console.log(data);
                window.location.href = "teacherLogin.html";
                resetForm(); 
            })
            .catch(error => {
                console.error("Error creating teacher:", error);
                alert("Something went wrong.");
            });
    });

    function resetForm() {
        teacherCurrentClass.value = "";
        teacherCurrentYear.value = "";
        teacherEmail.value = "";
        teacherName.value = "";
        teacherPhone.value = "";
        teacherPosition.value = "";
        teacherPassword.value = "";
        Deptdropdown.value = "";
        subjectDropdown.innerHTML = "<option disabled selected>Select Subject</option>";

    }
});