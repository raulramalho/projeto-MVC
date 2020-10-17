using AppBancoADO;
using AppBancoDominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDLL
{
    
   public class UsuarioDAO
    {
        private Banco db;
 
        string strInsereUsu;
        public void insert(usuario usuario) 
            {
                strInsereUsu = string.Format("insert into tbUsuario (NomeUsu, Cargo,DataNasc) " +
                    "values ('{0}','{1}','{2}');", usuario.NomeUsu, usuario.Cargo, (usuario.DataNasc).ToString("yyyy-MM-dd"));

                using (db = new Banco())
                {
                    db.ExecutaComando(strInsereUsu);

                }
            
        } 
        public void atualizar(int id)
        {
            usuario usuario = new usuario();
            var strquery = "";
            strquery += "update tbUsuario set ";
            strquery += string.Format("NomeUsu = '{0}', ",usuario.NomeUsu);
            strquery += string.Format("Cargo = '{0}', ", usuario.Cargo);
            strquery += string.Format("DataNasc = '{0}' ", usuario.DataNasc);
            strquery += string.Format("where IdUsu = {0};", id);

            using (db = new Banco())
            {
                db.ExecutaComando(strquery);
            }
        }
        public void salvar (usuario usuario)
        {     
           
                insert(usuario);
           
        }
        public void excluir(int id)
        {
            var strquery = string.Format("delete from tbUsuario where IdUsu = {0}", id);
            using (db = new Banco())
            {
                db.ExecutaComando(strquery);
            }
        }
        public List<usuario> listar()
        {
            var db = new Banco();
            var sqlquery = "select * from tbUsuario";
           var retorno = db.RetornaComando(sqlquery);
            return listausuario(retorno);
        }
        public List<usuario> listausuario(MySqlDataReader retorno)
        {
            var usuarios = new List<usuario>();
            while (retorno.Read())
            {
                var tempUsuario = new usuario()
                {
                    IdUsu = int.Parse(retorno["IdUsu"].ToString()),
                    NomeUsu = retorno["NomeUsu"].ToString(),
                    Cargo = retorno["Cargo"].ToString(),
                    DataNasc = DateTime.Parse(retorno["DataNasc"].ToString()),
                };
                usuarios.Add(tempUsuario);
            }
            return usuarios;
        }
    }
}
