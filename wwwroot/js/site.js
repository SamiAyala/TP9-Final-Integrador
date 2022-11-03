async function SHA256(string) {
    const utf8 = new TextEncoder().encode(string);
    return crypto.subtle.digest('SHA-256', utf8).then((hashBuffer) => {
      const hashArray = Array.from(new Uint8Array(hashBuffer));
      const hashHex = hashArray
        .map((bytes) => bytes.toString(16).padStart(2, '0'))
        .join('');
      return hashHex;
    });
}

async function checkHashed(input, result) {
  return await SHA256(input) == result;
}

function Registrar(){
	var nombre = $("#Nombre").val();
	var contraseña = SHA256($("#Contraseña").val());
  var contraseña2 = SHA256($("#Contraseña2").val());
  var imgUsuario = $("#imgUsuario").val();
  $.ajax(
    {
        type: 'POST',
        datatype: 'JSON',
        url: '/Home/Registrar',
        data: { Nombre : nombre, Contraseña : contraseña, Contraseña2 : contraseña2, imgUsuario : imgUsuario },
        success:
            function(response) {
                if (response) alert('YES!');
                else alert('NO :(');
            },
        error:
        function(xhr, status) {
            alert('Something happened, wasnt good, sorry :(');
        }
    }
);
}