async function SHA256(string) {
	const utf8 = new TextEncoder().encode(string);
	return crypto.subtle.digest("SHA-256", utf8).then((hashBuffer) => {
		const hashArray = Array.from(new Uint8Array(hashBuffer));
		const hashHex = hashArray
			.map((bytes) => bytes.toString(16).padStart(2, "0"))
			.join("");
		return hashHex;
	});
}

async function checkHashed(input, result) {
	return (await SHA256(input)) == result;
}

async function Registrar() {
	var nombre = $("#NombreRegister").val();
	var contraseña = await SHA256($("#ContraseñaRegister").val());
	var contraseña2 = await SHA256($("#Contraseña2").val());
	$.ajax({
		type: "POST",
		datatype: "JSON",
		url: "/Home/Registrar",
		data: { Nombre: nombre, Contraseña: contraseña, Contraseña2: contraseña2 },
		success: function (response) {
			if (response == "Ok") {
				$("#registerModal").modal("toggle");
				$("#notificationModalBody").html(
					"<h3><b>Successfuly registered, welcome to Chanonical!!</b></h3>"
				);
				$("#notificationModal").modal("toggle");
				$("#userName-cont").html(nombre);
				$("#button-cont").css("display", "none");
				$("#logout-btn").css("display", "block");
			} else if (response == "UsernameTaken") {
				$("#notificationModalBody").html(
					"<h3><b>Bad news! The username has already been taken, try another one!</b></h3>"
				);
				$("#notificationModal").modal("toggle");
			} else if (response == "PasswordsDontCoincide") {
				$("#notificationModalBody").html(
					"<h3><b>The passwords do not coincide, learn to type!</b></h3>"
				);
				$("#notificationModal").modal("toggle");
			}
		},
		error: function (xhr, status) {
			alert("Something happened, wasnt good, sorry :(");
		},
	});
}

async function Login() {
	var nombre = $("#NombreLogin").val();
	var contraseña = await SHA256($("#ContraseñaLogin").val());
	$.ajax({
		type: "POST",
		datatype: "JSON",
		url: "/Home/Login",
		data: { Nombre: nombre, Contraseña: contraseña },
		success: function (response) {
			if (response == "Ok") {
				$("#loginModal").modal("toggle");
				$("#notificationModalBody").html(
					"<h3><b>Successfuly logged in, welcome to Chanonical!!</b></h3>"
				);
				$("#notificationModal").modal("toggle");
				$("#userName-cont").html(nombre);
				$("#logout-btn").css("display", "block");
				$("#button-cont").css("display", "none");
			} else if (response == "Wrong") {
				$("#notificationModalBody").html(
					"<h3><b>Wrong password/username!</b></h3>"
				);
				$("#notificationModal").modal("toggle");
			}
		},
		error: function (xhr, status) {
			alert("Something happened, wasnt good, sorry :(");
		},
	});
}

async function LogOut() {
	$.ajax({
		type: "POST",
		datatype: "JSON",
		url: "/Home/LogOut",
		success: function (response) {
			$("#userName-cont").html(response);
			$("#logout-btn").css("display", "none");
			$("#button-cont").css("display", "block");
		},
		error: function (xhr, status) {
			alert("Something happened, wasnt good, sorry :(");
		},
	});
}
