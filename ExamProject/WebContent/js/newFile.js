document.addEventListener("DOMContentLoaded", () => {

    LoadTrueFalseQuestionAnswer();
    LoadChoiceQuestionAnswer();
    LoadBlankQuestionAnswer();
    LoadShortQuestionAnswer();

    const subjectTitle = document.getElementById("title");
    const subjectId = sessionStorage.getItem("subjectId");
    const subjectName = sessionStorage.getItem("subjectName");


    subjectTitle.textContent = `Subject : ${subjectName}`;

    async function LoadTrueFalseQuestionAnswer() {
        try {
            const teacherQARes = await fetch(apiBase);
            if (!teacherQARes.ok) throw new Error("Failed to fetch data");

            const teacherQAs = await teacherQARes.json();

            const tfQuestions = teacherQAs.filter(q => q.questionModeId === 1 && q.subjectId == subjectId && q.subjectId !== null
            );



            const tbody = document.getElementById("tftbody");
            tbody.innerHTML = "";

            tfQuestions.forEach((item, index) => {
                const row = document.createElement("tr");
                row.innerHTML = `
                <td>${index + 1}</td>
                <td>${item.question}</td>
                <td>${item.answer}</td>
                <td>
                    
                    <button class="btn btn-sm active" id="editbtn" onclick='editApplicantApplication(${item.teacherQuestionAnswerId})'>Update</button>
                    <button class="btn btn-sm active" id="editbtn" onclick='DeleteTeacherQA(${item.teacherQuestionAnswerId})'>Delete</button>
                </td>
            `;
                tbody.appendChild(row);
            });

        } catch (error) {
            console.error("Error loading questions:", error);
        }
    }

    async function LoadChoiceQuestionAnswer() {
        try {
            const teacherQARes = await fetch(apiBase);
            if (!teacherQARes.ok) throw new Error("Failed to fetch data");

            const teacherQAs = await teacherQARes.json();

            // Filter True/False questions (assume questionModeId == 1 is True/False)
            const tfQuestions = teacherQAs.filter(q => q.questionModeId === 2 && q.subjectId == subjectId && q.subjectId !== null
            );

            const tbody = document.getElementById("choicetbody");
            tbody.innerHTML = "";

            tfQuestions.forEach((item, index) => {
                const row = document.createElement("tr");
                row.innerHTML = `
                <td>${index + 1}</td>
                <td>${item.question}</td>
                <td>${item.answer}</td>
                <td>
                    
                    <button class="btn btn-sm active" id="editbtn" onclick='editApplicantApplication(${item.teacherQuestionAnswerId})'>Update</button>
                    <button class="btn btn-sm active" id="editbtn" onclick='editApplicantApplication(${item.teacherQuestionAnswerId})'>Delete</button>
                </td>
            `;
                tbody.appendChild(row);
            });
        } catch (error) {
            console.error("Error loading questions:", error);
        }
    }

    async function LoadBlankQuestionAnswer() {
        try {
            const teacherQARes = await fetch(apiBase);
            if (!teacherQARes.ok) throw new Error("Failed to fetch data");

            const teacherQAs = await teacherQARes.json();

            // Filter True/False questions (assume questionModeId == 1 is True/False)
            const tfQuestions = teacherQAs.filter(q => q.questionModeId === 3 && q.subjectId == subjectId && q.subjectId !== null
            );

            const tbody = document.getElementById("blanktbody");
            tbody.innerHTML = "";

            tfQuestions.forEach((item, index) => {
                const row = document.createElement("tr");
                row.innerHTML = `
                <td>${index + 1}</td>
                <td>${item.question}</td>
                <td>${item.answer}</td>
                <td>
                    
                    <button class="btn btn-sm active" id="editbtn" onclick='editApplicantApplication(${item.teacherQuestionAnswerId})'>Update</button>
                    <button class="btn btn-sm active" id="editbtn" onclick='editApplicantApplication(${item.teacherQuestionAnswerId})'>Delete</button>
                </td>
            `;
                tbody.appendChild(row);
            });
        } catch (error) {
            console.error("Error loading questions:", error);
        }
    }

    async function LoadShortQuestionAnswer() {
        try {
            const teacherQARes = await fetch(apiBase);
            if (!teacherQARes.ok) throw new Error("Failed to fetch data");

            const teacherQAs = await teacherQARes.json();

            // Filter True/False questions (assume questionModeId == 1 is True/False)
            const tfQuestions = teacherQAs.filter(q => q.questionModeId === 4 && q.subjectId == subjectId && q.subjectId !== null
            );

            const tbody = document.getElementById("shorttbody");
            tbody.innerHTML = "";

            tfQuestions.forEach((item, index) => {
                const row = document.createElement("tr");
                row.innerHTML = `
                <td>${index + 1}</td>
                <td>${item.question}</td>
                <td>${item.answer}</td>
                <td>
                    
                    <button class="btn btn-sm active" id="editbtn" onclick='editApplicantApplication(${item.teacherQuestionAnswerId})'>Update</button>
                    <button class="btn btn-sm active" id="editbtn" onclick='editApplicantApplication(${item.teacherQuestionAnswerId})'>Delete</button>
                </td>
            `;
                tbody.appendChild(row);
            });
        } catch (error) {
            console.error("Error loading questions:", error);
        }
    }


    function DeleteTeacherQA(int, qaId) {
        if (confirm("Are you sure you want to delete this question?")) {
            fetch(`${apiBase}/${qaId}`, {
                method: "DELETE"
            })
                .then(response => {
                    if (!response.ok) throw new Error("Failed to delete question");
                    LoadTrueFalseQuestionAnswer();
                    LoadChoiceQuestionAnswer();
                    LoadBlankQuestionAnswer();
                    LoadShortQuestionAnswer();
                })
                .catch(error => console.error("Error deleting question:", error));
        }
    }
});
