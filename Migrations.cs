using System.Data;

using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

using Orchard.Patrocinadores.Models;

namespace Orchard.Patrocinadores
{
    /// <summary>
    /// Repositorio de carregamento de Configurações, Estruturas de Dados, etc.
    /// </summary>
    public class Migrations : DataMigrationImpl
    {
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
                .ContentPartRecord()
                .Column("Nome", DbType.String)
                .Column("ContactoNome", DbType.String)
                .Column("ContactoTelefone", DbType.String)
                .Column("ContactoEmail", DbType.String)
                .Column("Observacoes", DbType.String)
            );

            return 1;
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Tem de ser "2" porque a função se chama "UpdateFrom1"</returns>
        public int UpdateFrom1()
        {
            // Creating table MapRecord
            SchemaBuilder.CreateTable("PatrocinioConfigurationRecord", table => table
                .ContentPartRecord()
                .Column("IDTipo", DbType.Int32)
                .Column("IDPatrocinador", DbType.Int32)
                .Column("URLImage", DbType.String)
            );

            ContentDefinitionManager.AlterPartDefinition(typeof(PatrocinioConfigurationPart).Name, cfg => cfg.Attachable());
            
         
            return 2;
        }
        */
        
        /*
        public int UpdateFrom2() {
            

            return 3;
        }

        
        public int UpdateFrom3() {
            
            return 4;
        }
		
        
        public int UpdateFrom4() {
            return 5;
        }
        */
    }
}