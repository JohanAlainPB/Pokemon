<%@ Page Title="Ver Pókemón" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallesInventario.aspx.cs" Inherits="inventario.DetallesInventario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    <h2>Ver Pokemóns</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #about-us {
            height: 650px;
            max-height: 650px;
        }

        .btnBuscar {
            margin: 5px 0;
        }
        .card {
            width: 350px;
            height: 496px;
            box-shadow: 0 1.5rem 4rem rgba(0,0,0,0.6);
            border-radius: 0.8rem;
            background-image: url(Imagenes/plantillaPokemon.png);
            background-repeat: no-repeat;
            background-size: contain;
            background-position:center;
        }
        .card-image {            
            margin-top: 3rem;
            align-items:center;
        }
        .image {
            margin-top:2rem;
            margin-left:3.5rem;
        }
        .card-text {
            margin-top:2rem;
            font-size: 1rem;
            text-align: center;
        }
        .nombre {
            font-size: 2rem;
            font-weight: 300;    
            position:absolute;
            margin-top: 11rem;
            margin-left: 7.5rem;  
            text-align: center;
            align-items: center;
        }
        .descripcion {
            padding: 0 2rem;
            font-size:1rem;
            position:absolute;
            margin-top: 14rem;
        }
        .card-stats {
            display: flex;
            font-size: x-small;
            position:absolute;
            top: 71%;
            margin-top: 3.5rem;
            margin-left: 13rem;   
        }
        .stats {
            padding: 0.5rem;                
        }
    </style>
    <section id="about-us">
        <div class="d-flex">
            <div class="box">
                <div class="col-lg-9">
                    <div class="row">
                        ID Pokemón
                        <asp:TextBox runat="server" ID="idPoke" />
                    </div>
                    <div class="col-lg-9">
                        <asp:Button runat="server" Text="Buscar" CssClass="btnBuscar" OnClick="btnBuscar_Click" />
                    </div>
                </div>
            </div>
            <div class="box">
                <div class="card" runat="server">
                    <div class="image" runat="server">
                        <asp:Image CssClass="image" runat="server" ID="imagenPokemon" />
                    </div>
                    <div class="card-text" runat="server">
                        <div class="nombre" id="nombrePokemon" runat="server"></div>  
                        <div class="descripcion" id="descripcionPokemon" runat="server"></div>                        
                    </div>
                    <div class="card-stats" runat="server">
                        <div class="stats">   
                            <label">Vida</label>
                            <div class="Vida" id="vidaPokemon" runat="server"></div>
                            <label>Habilidad</label>
                            <div class="Velociad" id="habilidadPokemon" runat="server"></div>
                        </div>
                        <div class="stats">
                            <label>Ataque</label>
                            <div class="ataque" id="ataquePokemon" runat="server"></div>
                            <label>Defensa</label>
                            <div class="defensa" id="defensaPokemon" runat="server"></div>
                        </div>
                    </div>
                </div>                
            </div>
        </div>
    </section>
</asp:Content>