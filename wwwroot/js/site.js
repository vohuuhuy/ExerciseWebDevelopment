const calculator = document.querySelector("#calculator")
const listCaculator = document.querySelector("#list-calculator")
let openListCaculator = false

const student = document.querySelector("#student")
const listStudent = document.querySelector("#list-mode-student")
let openListStudent = false

const handleCalculatorClick = () => {
  if (listCaculator.classList.contains("open-modal-hover")) {
    listCaculator.classList.remove("open-modal-hover")
    openListCaculator = true
  } else {
    openListCaculator = true
    listCaculator.classList.add("open-modal-hover")
  }
}

const handleListCalculatorMouseLeave = () => {
  if (openListCaculator) {
    listCaculator.classList.remove("open-modal-hover")
    openListCaculator = false
  }
}

const handleStudentClick = () => {
  if (listStudent.classList.contains("open-modal-hover")) {
    listStudent.classList.remove("open-modal-hover")
    openlistStudent = true
  } else {
    openlistStudent = true
    listStudent.classList.add("open-modal-hover")
  }
}

const handleListStudentMouseLeave = () => {
  if (openlistStudent) {
    listStudent.classList.remove("open-modal-hover")
    openlistStudent = false
  }
}

calculator.addEventListener("click", handleCalculatorClick)
listCaculator.addEventListener("mouseleave", handleListCalculatorMouseLeave)

student.addEventListener("click", handleStudentClick)
listStudent.addEventListener("mouseleave", handleListStudentMouseLeave)
$(".custom-file-input").on("change", function() {
  var fileName = $(this).val().split("\\").pop();
  $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
});