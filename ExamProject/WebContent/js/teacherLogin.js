document.addEventListener("DOMContentLoaded", () => {
    const dropdown = document.getElementById("departmentDropdown");
    const loginBtn = document.getElementById("loginbtn");
    const teachername = document.getElementById("username");
    const email = document.getElementById("email");
    const password = document.getElementById("password");

    const departmentApi = "https://localhost:7104/api/Department";
    const teacherApi = "https://localhost:7104/api/Teacher/teacherlogin";
    const departmentIdApi = "https://localhost:7104/api/Department/dept"

    // Load departments
    fetch(departmentApi)
        .then(response => response.json())
        .then(data => {
            dropdown.innerHTML = "";
            data.forEach(dept => {
                const option = document.createElement("option");
                option.value = dept.department1;
                option.textContent = dept.department1;
                dropdown.appendChild(option);
            });
        })
        .catch(error => {
            console.error("Error loading departments:", error);
            dropdown.innerHTML = `<option disabled>Error loading</option>`;
        });

    // Login button logic
    loginBtn.addEventListener("click", function (event) {
        event.preventDefault();

        const selectedDept = dropdown.value;
        const inputName = teachername.value.trim();
        const inputEmail = email.value.trim();
        const inputPassword = password.value.trim();

        if (!selectedDept || !inputName || !inputEmail || !inputPassword) {
            alert("Please fill in all fields.");
            return;
        }

        // First fetch all teachers to verify credentials
        fetch(teacherApi)
            .then(response => response.json())
            .then(data => {
                const teacherMatch = data.find(t => t.teacherName === inputName);

                if (!teacherMatch) {
                    alert("Invalid username.");
                    return;
                }

                if (teacherMatch.teacherEmail !== inputEmail) {
                    alert("Invalid email.");
                    return;
                }

                if (teacherMatch.teacherPassword !== inputPassword) {
                    alert("Invalid password.");
                    return;
                }

                
                sessionStorage.setItem("teacherId", teacherMatch.teacherId);
                sessionStorage.setItem("teacherName", teacherMatch.teacherName);
                sessionStorage.setItem("selectedDepartment", selectedDept);


               
                fetch(`${departmentIdApi}/${teacherMatch.departmentId}`)
                    .then(res => res.json())
                    .then(department => {
                        const classList = department.classes.map(cls => ({
                            class1: cls.class1,
                            year: cls.year
                        }));

                        
                        if (classList.length > 0) {
                            sessionStorage.setItem("class1", classList[0].class1);
                            sessionStorage.setItem("year", classList[0].year);
                        }

                        
                        window.location.href = "teachersubjectList.html";
                    })
                    .catch(err => {
                        console.error("Error loading department details:", err);
                        alert("Failed to fetch class/year data.");
                    });

            })
            .catch(error => {
                console.error("Error during login:", error);
                alert("Login failed. Try again later.");
            });
    });
});
