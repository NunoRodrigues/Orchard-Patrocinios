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

        private IRepository<PatrocinadorRecord> _patrocinadorRepository;
        public Migrations(IRepository<PatrocinadorRecord> patrocinadorRepository)
        {
            _patrocinadorRepository = patrocinadorRepository;
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
            // Widget - Tabela
            SchemaBuilder.CreateTable(typeof(PatrocinioWidgetRecord).Name, table => table
                .ContentPartRecord()
                .Column("Width", DbType.Int32)
                .Column("Height", DbType.Int32)
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
                .Column<int>("IdTipo")
                .Column<DateTime>("DataInicio")
                .Column<DateTime>("DataFim")
                .Column<string>("URLImage")
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