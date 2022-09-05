<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CamaroneraNetFramework.Vista.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Camaronera Sandra</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js"></script>
<script src="https://code.jquery.com/jquery-3.5.1.js"></script>
<script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <label class="text-center">Camaronera Sandra</label>
            </div>
            <div>
                <button class="btn btn-success btn-sm" type="button" onclick="GuardarProducto()">Guardar </button>
                <button class="btn btn-info btn-sm" type="button" onclick="Listado()">Consultar </button>
                <button class="btn btn-warning btn-sm" type="button" onclick="Salida()">SalidaPRoducto </button>
            </div>
            <div>
                <div class="card-body">
                    <div class="card-datable table-responsive">
                        <table id="tablaListado" class="table table-danger" width="100%">
                            <thead>
                                <tr>
                                    <th>id</th>
                                    <th>Nombre</th>
                                    <th>Descripcion</th>
                                    <th>Cantidad</th>
                                    <th>Accion</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

<div class="modal inmodal" id="MyModal" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-xl">
        <div class="modal-content animated bounceInRight" style="width:100%">
            <div class="modal-body">
                <div class="row">
                    <center><h5 style="color:black"><strong>Información del camaron</strong></h5></center>
                    <div class="col-sm-12">
                        <div class="col-md-3 text-dark small">Nombre:</div>
                        <div class="col-md-8">
                            <input type="text" id="txtNombre" autocomplete="off" class="form-control form-control-sm" />
                        </div>
                        <div class="col-md-3 text-dark small">Descripcion:</div>
                        <div class="col-md-8">
                            <input type="text" id="txtDescripcion" autocomplete="off" class="form-control form-control-sm" />
                        </div>
                        <div class="col-md-3 text-dark small">Cantidad:</div>
                        <div class="col-md-8">
                            <input type="text" id="txtCantidad" autocomplete="off" class="form-control form-control-sm" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer" style="float:right !important">
                <button id="BtnGuardar" style="display:none" runat="server" class="btn btn-success btn-sm" type="button" onclick="Guardar()">Guardar </button>
                <button id="BtnEditar" style="display:none" runat="server" class="btn btn-success btn-sm" type="button" onclick="Editar()">Editar </button>
                <button id="BtnCerrar" runat="server" class="btn btn-danger btn-sm" type="button" onclick="CerrarModal()">Cerrar </button>
            </div>
        </div>
    </div>
</div>

<div class="modal inmodal" id="MyModalSalida" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-xl">
        <div class="modal-content animated bounceInRight" style="width:100%">
            <div class="modal-body">
                <div class="row">
                    <center><h5 style="color:black"><strong>Salida del producto</strong></h5></center>
                    <div class="col-sm-12">
                        <div class="col-md-3 text-dark small">Nombre:</div>
                        <div class="col-md-8">
                            <select id="cmbCamaron" class="form-control form-control-sm">
                                <option value="0">--Seleccione--</option>
                            </select>
                        </div>
                        <div class="col-md-3 text-dark small">Cantidad:</div>
                        <div class="col-md-8">
                            <input type="text" id="txtCantidadSalida" autocomplete="off" class="form-control form-control-sm" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer" style="float:right !important">
                <button id="Button1" runat="server" class="btn btn-success btn-sm" type="button" onclick="GuardarSalida()">Guardar </button>
                <button id="Button2" runat="server" class="btn btn-danger btn-sm" type="button" data-dismiss="modal">Cerrar </button>
            </div>
        </div>
    </div>
</div>





<script>
    var tableListado;
    var idRegistro;

    $(document).ready(function () {
        $("#tablaListado").css("font-size", "9pt");
        Listado();

    });
    function Listado() {
        jQuery.ajax({
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
            }),
            dataType: 'JSON',
            url: "index.aspx/Listado",
           
            success: function (results) {
                tableListado = $("#tablaListado").DataTable({
                    data: jQuery.parseJSON(results.d),
                    destroy: true,
                    deferRender: true,
                    select: true,
                    scroller: true,
                    scrollCollapse: true,
                    scrollX: true,
                    scrollY: 500,
                    paging: true,
                    pageLength: 100,
                    searching: false,
                    showNEntries: false,
                    responsive: true,
                    "ordering": true,
                    dom: '<"html5buttons"B>lTfgitp',
                    "bLengthChange": false,
                    buttons: [
                        {
                            extend: 'excel',

                        }
                    ],
                    columns: [
                        { data: "Id" },
                        { data: "Nombre" },
                        { data: "Descripcion" },
                        { data: "Cantidad" },
                        {
                            data: "Id",
                            "render": function (data, type, row) {
                                return '<a class="btn-sm"  onclick="AbriModalEditar(' + row.Id + ')">Editar</a>';
                            }
                        }
                    ]
                });
            }
        })
    }

    function ListarProducto() {
        jQuery.ajax({
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
            }),
            dataType: 'JSON',
            url: "index.aspx/ListarProducto",

            success: function (results) {
                var datos = $.parseJSON(results.d);
                $("#cmbCamaron").empty().append("<option value=0 selected>--Seleccione--</option>");
                $(datos).each(function () {
                    var option = $(document.createElement("option"));
                    option.val(this.Id);
                    option.text(this.Nombre);
                    $("#cmbCamaron").append(option);
                })
            }
        })
    }

    function AbriModalEditar(id) {


        $("#MyModal").show();
        idRegistro = id;
        ObtenerInformacionCamaron(id);
        document.getElementById('BtnEditar').style.display = 'block';
        document.getElementById('BtnGuardar').style.display = 'none';

    }

    function Salida() {
        $("#MyModalSalida").show();
        ListarProducto();
    }

    function GuardarProducto() {
        $("#MyModal").show();
        document.getElementById('BtnEditar').style.display = 'none';
        document.getElementById('BtnGuardar').style.display = 'block';

    }

    function ObtenerInformacionCamaron(id) {
        jQuery.ajax({
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                id:id
            }),
            dataType: 'JSON',
            url: "index.aspx/ObtenerInformacionCamaron",
            success: function (results) {
                console.log(results);
                var dato=jQuery.parseJSON(results.d)
                $("#txtNombre").val(dato.Nombre);
                $("#txtDescripcion").val(dato.Descripcion);
                $("#txtCantidad").val(dato.Cantidad);
            }
        })
    }

    function Editar() {
        var nombre = $("#txtNombre").val();
        var descripcion = $("#txtDescripcion").val();
        var cantidad = $("#txtCantidad").val();
        jQuery.ajax({
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                id: idRegistro,
                nombre: nombre,
                descripcion: descripcion,
                cantidad: cantidad
            }),
            dataType: 'JSON',
            url: "index.aspx/Editar",
            success: function (results) {

                console.log(results);
                alert(results.d)
                CerrarModal();
                Listado();
            }
        })
    }

    function Guardar() {
        var nombre = $("#txtNombre").val();
        var descripcion = $("#txtDescripcion").val();
        var cantidad = $("#txtCantidad").val();

        jQuery.ajax({
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                nombre: nombre,
                descripcion: descripcion,
                cantidad: cantidad
            }),
            dataType: 'JSON',
            url: "index.aspx/Guardar",
            success: function (results) {
                console.log(results);
                alert(results.d)
                $("#MyModal").hide();
                Listado();
            }
        })
    }

    function GuardarSalida() {
        var id = $("#cmbCamaron").val();
        var cantidad = $("#txtCantidadSalida").val();

        jQuery.ajax({
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                id: id,
                cantidad: cantidad
            }),
            dataType: 'JSON',
            url: "index.aspx/RegitrarSalida",
            success: function (results) {
                console.log(results);
                alert(results.d)
                CerrarModal2();
                Listado();
            }
        })
    }

    function CerrarModal() {
        $("#MyModal").hide();
    }

    function CerrarModal2() {
        $("#MyModalSalida").hide();
    }

</script>

                                                                                                                      >