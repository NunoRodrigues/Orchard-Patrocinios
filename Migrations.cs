using System;
using System.Data;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data;
using Orchard.Data.Migration;
using Orchard.Patrocinadores.Models;

namespace Orchard.Patrocinadores
{
    /// <summary>
    /// Repositorio de carregamento de Configurações, Estruturas de Dados, etc.
    /// </summary>
    public class Migrations : DataMigrationImpl
    {

        private IRepository<PatrocinioWidgetTipoRecord> _widgetTipoRecord;

        public Migrations(IRepository<PatrocinioWidgetTipoRecord> widgetTipoRecord, IRepository<PatrocinioWidgetTipoPart> widgetTipoRecord2)
        {
            _widgetTipoRecord = widgetTipoRecord;
        }
        /// <summary>
        ///     Primeiro Metodo que é chamado quando se instala o Modulo.
        ///     Os consequentes metodos são chamados "UpdateFromX" em que X é um Numero e essa mesma função retorna sempre "X + 1"
        /// </summary>
        /// <returns>
        ///     Numero de Versão, sendo este o "Create", é sempre "1".
        ///     Os Restantes Metodos serão sempre "UpdateFromX"
        ///     Para fazer reset Manual da Versão do Modulo basta alterar o registo correspondente na Tabela "*_Orchard_Framework_DataMigrationRecord"
        /// </returns>
        public int Create()
        {

            // WidgetTipo - Tabela
            SchemaBuilder.CreateTable(typeof(PatrocinioWidgetTipoRecord).Name, table => table
                .Column<int>("Id", column => column.PrimaryKey().Identity())
                .Column("Tipo", DbType.String)
                .Column("Width", DbType.Int32)
                .Column("Height", DbType.Int32)
                .Column("PosTop", DbType.Int32)
                .Column("PosLeft", DbType.Int32)
                .Column("Color", DbType.String)
            );

            // WidgetTipo - Dados
            _widgetTipoRecord.Update(new PatrocinioWidgetTipoRecord() { Id = 1, Tipo = "Left", Width = 9, Height = 22, PosTop = 12, PosLeft = 0, Color = "#F7C43C !important" });
            _widgetTipoRecord.Update(new PatrocinioWidgetTipoRecord() { Id = 2, Tipo = "Right", Width = 9, Height = 22, PosTop = 12, PosLeft = 37, Color = "#A346EE !important" });
            _widgetTipoRecord.Update(new PatrocinioWidgetTipoRecord() { Id = 3, Tipo = "Top", Width = 46, Height = 9, PosTop = 0, PosLeft = 0, Color = "#349ED7 !important" });
            _widgetTipoRecord.Update(new PatrocinioWidgetTipoRecord() { Id = 4, Tipo = "Bottom", Width = 46, Height = 9, PosTop = 37, PosLeft = 0, Color = "#51DB5E !important" });

            // Widget - Tabela
            SchemaBuilder.CreateTable(typeof(PatrocinioWidgetRecord).Name, table => table
                .ContentPartRecord()
                .Column("Width", DbType.Int32)
                .Column("Height", DbType.Int32)
                .Column(typeof(PatrocinioWidgetTipoRecord).Name + "_Id", DbType.Int32)
            );

            // Widget - 
            ContentDefinitionManager.AlterPartDefinition(typeof(PatrocinioWidgetPart).Name, cfg => cfg.Attachable());

            // Widget - Cria um Widget content, o Nome é o nome que aparece ao Utilizador
            ContentDefinitionManager.AlterTypeDefinition("Patrocínio", cfg => cfg
                .WithPart(typeof(PatrocinioWidgetPart).Name)
                .WithPart("WidgetPart")
                .WithPart("CommonPart")
                .WithSetting("Stereotype", "Widget"));

            // Patrocinadores - Tabela
            SchemaBuilder.CreateTable(typeof(PatrocinadorRecord).Name, table => table
                .Column<int>("Id", col => col.PrimaryKey().Identity())
                .Column("Nome", DbType.String)
                .Column("ContactoNome", DbType.String)
                .Column("ContactoTelefone", DbType.String)
                .Column("ContactoEmail", DbType.String)
                .Column("Observacoes", DbType.String)
            );


            // PatrocinioPart - Tabela 
            SchemaBuilder.CreateTable(typeof(PatrociniosPartRecord).Name, table => table
                .ContentPartRecord()
            );


            // Patrocinio - Tabela
            SchemaBuilder.CreateTable(typeof(PatrocinioItemRecord).Name, table => table
                .Column<int>("Id", column => column.PrimaryKey().Identity())
                .Column<int>(typeof(PatrociniosPartRecord).Name + "_Id", c => c.NotNull())
                .Column<int>(typeof(PatrocinadorRecord).Name + "_Id", c => c.NotNull())
                .Column<int>(typeof(PatrocinioWidgetTipoRecord).Name + "_Id", c => c.NotNull())
                .Column<DateTime>("DataInicio")
                .Column<DateTime>("DataFim")
                .Column<string>("URLImage")
                .Column<string>("ExternalLink")
            );

            // Patrocinio - Foreign Key com Patrocinadores
            SchemaBuilder.CreateForeignKey("FK_" + typeof(PatrocinioItemRecord).Name + "_" + typeof(PatrocinadorRecord).Name
                , "Patrocinadores"
                , typeof(PatrocinioItemRecord).Name
                , new[] { typeof(PatrocinadorRecord).Name + "_Id" }
                , typeof(PatrocinadorRecord).Name
                , new[] { "Id" });

            // Patrocinio - Foreign Key com Part
            SchemaBuilder.CreateForeignKey("FK_" + typeof(PatrocinioItemRecord).Name + "_" + typeof(PatrociniosPartRecord).Name
                , "Patrocinadores"
                , typeof(PatrocinioItemRecord).Name
                , new[] { typeof(PatrociniosPartRecord).Name + "_Id" }
                , typeof(PatrociniosPartRecord).Name
                , new[] { "Id" });


            // Configuração - Patrocinio
            ContentDefinitionManager.AlterPartDefinition(typeof(PatrociniosPart).Name, cfg => cfg.Attachable());

            return 1;
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Tem de ser "2" porque a função se chama "UpdateFrom1"</returns>
        public int UpdateFrom1()
        {


            return 2;
        }
         */
    }
}