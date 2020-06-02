function hideLabel(labelToHide, inputToDisplay) {
	document.getElementById(labelToHide).style.display = "none";
	document.getElementById(inputToDisplay).style.display = "block";
	document.getElementById(inputToDisplay).focus();
}
function saveLabel(inputLabelToHide, labelToDisplay) {
	document.getElementById(labelToDisplay).style.display = "block";
	document.getElementById(labelToDisplay).innerHTML = document.getElementById(inputLabelToHide).value;
	document.getElementById(inputLabelToHide).style.display = "none";
}
function message(e) {
	alert('Изменения сохранены');
	return false;
}
function checkNewPassword(e) {
	if (document.getElementById("newPassword").value != document.getElementById("repeatNewPassword").value) {
		alert('Проверьте новый пароль');
		return false;
	}
}