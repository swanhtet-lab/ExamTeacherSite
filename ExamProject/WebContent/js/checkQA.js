const apiBase = "https://localhost:7104/api/TeacherQA";
const subjectApiBase = "https://localhost:7104/api/Subject";
let currentQuestionModeId = null;

document.addEventListener("DOMContentLoaded", () => {
    LoadTrueFalseQuestionAnswer();
    LoadChoiceQuestionAnswer();
    LoadBlankQuestionAnswer();
    LoadShortQuestionAnswer();

    const subjectTitle = document.getElementById("title");
    const subjectId = sessionStorage.getItem("subjectId");
    const subjectName = sessionStorage.getItem("subjectName");
    const subjectStatus = sessionStorage.getItem("subjectStatus");
    const tfavailablebtn = document.getElementById("availablebtn");
    const choiceAvailablebtn = document.getElementById("availableCbtn");
    const bAvailablebtn = document.getElementById("availableBbtn");
    const shortAvailabebtn = document.getElementById("availableSbtn");

    subjectTitle.textContent = `Subject : ${subjectName}`;

    tfavailablebtn.addEventListener("click", () => submitAvailable(1));

    choiceAvailablebtn.addEventListener("click", () => submitAvailable(2));

    bAvailablebtn.addEventListener("click", () => submitAvailable(3));

    shortAvailabebtn.addEventListener("click", () => submitAvailable(4));

    function submitAvailable(questionModeId) {
        if (subjectStatus === "Available") {
            alert("This subject is already available for question answering.");
            const btn = document.getElementById(getButtonIdByMode(questionModeId));
            btn.classList.remove("btn-danger", "btn-secondary", "btn-primary");
            btn.classList.add("btn-success");
            btn.textContent = "Now Available!";
        } else {
            const confirmAvailable = confirm("Are you sure you want to make this subject available for question answering?");
            if (confirmAvailable) {
                sessionStorage.setItem("questionModeId", questionModeId);

                //fetch(`${subjectApiBase}/${subjectId}/status`, {
                //    method: "PATCH",
                //    headers: {
                //        "Content-Type": "application/json"
                //    },
                //    body: JSON.stringify("Available")
                //})
                //    .then(res => {
                //        if (!res.ok) throw new Error("Failed to update availability");


                //        // Update button appearance
                //        const btn = document.getElementById(getButtonIdByMode(questionModeId));
                //        btn.classList.remove("btn-danger", "btn-secondary", "btn-primary");
                //        btn.classList.add("btn-success");
                //        btn.textContent = "Now Available!";

                //        alert(questionModeId);

                //        // Update session status and pass questionModeId
                //        sessionStorage.setItem("subjectStatus", "Available");
                //        sessionStorage.setItem("questionModeId", questionModeId);


                //    })
                //    .catch(err => {
                //        console.error(err);
                //        alert("Error updating availability.");
                //    });
            }
        }
    }

    async function LoadTrueFalseQuestionAnswer() {
        try {
            const teacherQARes = await fetch(apiBase);
            if (!teacherQARes.ok) throw new Error("Failed to fetch data");

            const teacherQAs = await teacherQARes.json();
            const tfQuestions = teacherQAs.filter(q =>
                q.questionModeId === 1 &&
                q.subjectId !== null &&
                q.subjectId == subjectId
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
                        <button class="btn btn-sm btn-warning" onclick='editApplicantApplication(${item.teacherQuestionAnswerId}, 1)'>Update</button>
                        <button class="btn btn-sm btn-danger" onclick='DeleteTeacherQA(${item.teacherQuestionAnswerId})'>Delete</button>
                    </td>
                `;
                tbody.appendChild(row);
            });
        } catch (error) {
            console.error("Error loading TF questions:", error);
        }
    }

    async function LoadChoiceQuestionAnswer() {
        try {
            const teacherQARes = await fetch(apiBase);
            if (!teacherQARes.ok) throw new Error("Failed to fetch data");

            const teacherQAs = await teacherQARes.json();
            const questions = teacherQAs.filter(q =>
                q.questionModeId === 2 &&
                q.subjectId !== null &&
                q.subjectId == subjectId
            );

            const tbody = document.getElementById("choicetbody");
            tbody.innerHTML = "";

            questions.forEach((item, index) => {
                const row = document.createElement("tr");
                row.innerHTML = `
                    <td>${index + 1}</td>
                    <td>${item.question}</td>
                    <td>${item.answer}</td>
                    <td>
                        <button class="btn btn-sm btn-warning" onclick='editApplicantApplication(${item.teacherQuestionAnswerId}, 2)'>Update</button>
                        <button class="btn btn-sm btn-danger" onclick='DeleteTeacherQA(${item.teacherQuestionAnswerId})'>Delete</button>
                    </td>
                `;
                tbody.appendChild(row);
            });
        } catch (error) {
            console.error("Error loading Choice questions:", error);
        }
    }

    async function LoadBlankQuestionAnswer() {
        try {
            const teacherQARes = await fetch(apiBase);
            if (!teacherQARes.ok) throw new Error("Failed to fetch data");

            const teacherQAs = await teacherQARes.json();
            const questions = teacherQAs.filter(q =>
                q.questionModeId === 3 &&
                q.subjectId !== null &&
                q.subjectId == subjectId
            );

            const tbody = document.getElementById("blanktbody");
            tbody.innerHTML = "";

            questions.forEach((item, index) => {
                const row = document.createElement("tr");
                row.innerHTML = `
                    <td>${index + 1}</td>
                    <td>${item.question}</td>
                    <td>${item.answer}</td>
                    <td>
                        <button class="btn btn-sm btn-warning" onclick='editApplicantApplication(${item.teacherQuestionAnswerId}, 3)'>Update</button>
                        <button class="btn btn-sm btn-danger" onclick='DeleteTeacherQA(${item.teacherQuestionAnswerId})'>Delete</button>
                    </td>
                `;
                tbody.appendChild(row);
            });
        } catch (error) {
            console.error("Error loading Blank questions:", error);
        }
    }

    async function LoadShortQuestionAnswer() {
        try {
            const teacherQARes = await fetch(apiBase);
            if (!teacherQARes.ok) throw new Error("Failed to fetch data");

            const teacherQAs = await teacherQARes.json();
            const questions = teacherQAs.filter(q =>
                q.questionModeId === 4 &&
                q.subjectId !== null &&
                q.subjectId == subjectId
            );

            const tbody = document.getElementById("shorttbody");
            tbody.innerHTML = "";

            questions.forEach((item, index) => {
                const row = document.createElement("tr");
                row.innerHTML = `
                    <td>${index + 1}</td>
                    <td>${item.question}</td>
                    <td>${item.answer}</td>
                    <td>
                        <button class="btn btn-sm btn-warning" onclick='editApplicantApplication(${item.teacherQuestionAnswerId}, 4)'>Update</button>
                        <button class="btn btn-sm btn-danger" onclick='DeleteTeacherQA(${item.teacherQuestionAnswerId})'>Delete</button>
                    </td>
                `;
                tbody.appendChild(row);
            });
        } catch (error) {
            console.error("Error loading Short questions:", error);
        }
    }
});

// DELETE
async function DeleteTeacherQA(id) {
    if (!confirm("Are you sure you want to delete this question?")) return;

    try {
        const res = await fetch(`${apiBase}/${id}`, { method: "DELETE" });
        if (!res.ok) throw new Error("Delete failed");
        alert("Deleted successfully");
        location.reload();
    } catch (err) {
        console.error(err);
        alert("Error deleting question");
    }
}

// OPEN MODAL FOR EDITING
function editApplicantApplication(id, modeId) {
    currentQuestionModeId = modeId;
    fetchQuestionForEdit(id);
}

// FETCH QUESTION FOR MODAL
async function fetchQuestionForEdit(id) {
    try {
        const res = await fetch(`${apiBase}/${id}`);
        if (!res.ok) throw new Error("Fetch failed");

        const data = await res.json();
        document.getElementById("editId").value = data.teacherQuestionAnswerId;
        document.getElementById("editQuestion").value = data.question;
        document.getElementById("editAnswer").value = data.answer;

        const modal = new bootstrap.Modal(document.getElementById('editModal'));
        modal.show();
    } catch (err) {
        console.error(err);
        alert("Failed to load question");
    }
}

// SUBMIT UPDATE FORM
document.getElementById("updateForm").addEventListener("submit", async (e) => {
    e.preventDefault();

    const id = document.getElementById("editId").value;
    const updatedQuestion = document.getElementById("editQuestion").value.trim();
    const updatedAnswer = document.getElementById("editAnswer").value.trim();

    const subjectId = sessionStorage.getItem("subjectId");
    const questionModeId = currentQuestionModeId;

    const updatePayload = {
        teacherQuestionAnswerId: parseInt(id),
        question: updatedQuestion,
        answer: updatedAnswer,
        subjectId: parseInt(subjectId),
        questionModeId: questionModeId
    };

    try {
        const res = await fetch(`${apiBase}/${id}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(updatePayload)
        });

        if (!res.ok) throw new Error("Update failed");

        alert("Updated successfully");
        location.reload();
    } catch (err) {
        console.error(err);
        alert("Error updating question");
    }
});

// Helper to get button ID by questionModeId
function getButtonIdByMode(modeId) {
    switch (modeId) {
        case 1: return "availablebtn";
        case 2: return "availableCbtn";
        case 3: return "availableBbtn";
        case 4: return "availableSbtn";
        default: return "";
    }
}
