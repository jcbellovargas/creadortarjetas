hayConyugue = false;
$("#conyugue").change(function () {
    if ($("#conyugue").val() == "Si") {
        $("#conyugue_container").show();
    } else {
        $("#conyugue_container").hide();
    }
});

$("#foto_dialog").dialog({
    autoOpen: false,
    height: 350,
    width: 400,
});

function isConyugueElement(e) {
    return $("#conyugue_container").find(e).length > 0;
}

var sayCheese = new SayCheese('#foto_dialog', { snapshots: true });

sayCheese.on('snapshot', function (snapshot) {
    var img = document.createElement('img');
    img.src = snapshot.toDataURL('image/png');
    var result = snapshot.toDataURL('image/png');

    var link = document.createElement("a");

    link.setAttribute("href", result);
    var basename = $("#foto_dialog").data().isConyugue ? $("#Persona_Persona2_nombre").val() + "_" + $("#Persona_Persona2_apellido").val() : $("#Persona_nombre").val() + "_" + $("#Persona_apellido").val();
    var filename = basename + "_" + Math.floor((Math.random() * 10000) + 1) + ".png";
    link.setAttribute("download", filename);
    link.click();
    $("#foto_dialog").data().isConyugue ? $("#Persona_Persona2_foto").val(filename) : $("#Persona_foto").val(filename)
});

sayCheese.start();

$(".foto").click(function () {
    $("#foto_dialog").data('isConyugue', isConyugueElement(this)).dialog('open');
});

$("#btn_foto").click(function () {
    sayCheese.takeSnapshot(200, 200);
    sayCheese.stop();
});

$("#solicitud_form").validate({
    // Specify the validation rules
    rules: {
        "Persona.nombre": "required",
        "Persona.apellido": "required",
        "Persona.sexo": "required",
        "Persona.fecha_nacimiento": "required",
        "Persona.tipo_documento": "required",
        "Persona.nro_documento": "required",
        "Persona.domicilio": "required",
        "Persona.situacion_laboral": "required",
        "Persona.ingreso_promedio": "required",
        "Persona.email": "required",
        "Persona.telefono": "required",
        "Persona.foto": "required",
        "Persona.Persona2.nombre": { required: function () { return $("#conyugue").val() == "Si" } },
        "Persona.Persona2.apellido": { required: function () { return $("#conyugue").val() == "Si" } },
        "Persona.Persona2.sexo": { required: function () { return $("#conyugue").val() == "Si" } },
        "Persona.Persona2.fecha_nacimiento": { required: function () { return $("#conyugue").val() == "Si" } },
        "Persona.Persona2.tipo_documento": { required: function () { return $("#conyugue").val() == "Si" } },
        "Persona.Persona2.nro_documento": { required: function () { return $("#conyugue").val() == "Si" } },
        "Persona.Persona2.domicilio": { required: function () { return $("#conyugue").val() == "Si" } },
        "Persona.Persona2.situacion_laboral": { required: function () { return $("#conyugue").val() == "Si" } },
        "Persona.Persona2.ingreso_promedio": { required: function () { return $("#conyugue").val() == "Si" } },
        "Persona.Persona2.email": { required: function () { return $("#conyugue").val() == "Si" } },
        "Persona.Persona2.telefono": { required: function () { return $("#conyugue").val() == "Si" } },
        "Persona.Persona2.foto": { required: function () { return $("#conyugue").val() == "Si" } }
    },
        
    // Specify the validation error messages
    messages: {
        "Persona.nombre": "Por favor ingrese su nombre",
        "Persona.apellido": "Por favor ingrese su apellido",
        "Persona.sexo": "Debe seleccionar sexo",
        "Persona.fecha_nacimiento": "Ingrese su fecha de nacimiento",
        "Persona.tipo_documento": "Ingrese tipo de documento",
        "Persona.nro_documento": "Debe ingresar numero de documento",
        "Persona.domicilio": "Debe ingresar domicilio",
        "Persona.situacion_laboral": "Ingrese situacion laboral",
        "Persona.ingreso_promedio": "Ingrese su ingreso promedio",
        "Persona.email": "Debe ingresar un correo electronico valido",
        "Persona.telefono": "Por favor ingrese un telefono",
        "Persona.foto": "Debe adjuntar una foto",
        "Persona.Persona2.nombre": "Por favor ingrese su nombre",
        "Persona.Persona2.apellido": "Por favor ingrese su apellido",
        "Persona.Persona2.sexo": "Debe seleccionar sexo",
        "Persona.Persona2.fecha_nacimiento": "Ingrese su fecha de nacimiento",
        "Persona.Persona2.tipo_documento": "Ingrese tipo de documento",
        "Persona.Persona2.nro_documento": "Debe ingresar numero de documento",
        "Persona.Persona2.domicilio": "Debe ingresar domicilio",
        "Persona.Persona2.situacion_laboral": "Ingrese situacion laboral",
        "Persona.Persona2.ingreso_promedio": "Ingrese su ingreso promedio",
        "Persona.Persona2.email": "Debe ingresar un correo electronico valido",
        "Persona.Persona2.telefono": "Por favor ingrese un telefono",
        "Persona.Persona2.foto": "Debe adjuntar una foto"
    },
        
    submitHandler: function(form) {
        form.submit();
    }
});