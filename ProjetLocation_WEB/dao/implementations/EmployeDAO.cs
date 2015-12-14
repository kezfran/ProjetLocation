using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLocation.db;
using MySql.Data.MySqlClient;
using ProjetLocation.dto;
using ProjetLocation.exception.dao;
using ProjetLocation.dao.interfaces;

namespace ProjetLocation.dao.implementations
{
    public class EmployeDAO : IEmployeDAO
    {
        public Connexion connexion { get; set; }
        public MySqlCommand command { get; set; }
        private static string ADD_REQUEST = @"INSERT into employe (nom,poste,matricule,motPasse) " +
            "VALUES(@nom, @poste, @matricule,@motPasse)";

        private static string READ_REQUEST = @"SELECT * FROM employe WHERE idEmploye = @idEmploye";

        private static string UPDATE_REQUEST = @"UPDATE employe set nom = @nom, poste = @poste, matricule = @matricule, motPasse = @motPasse " +
            "WHERE idEmploye = @idEmploye";

        private static string DELETE_REQUEST = @"DELETE from employe WHERE idEmploye = @idEmploye";

        private static string GET_ALL_REQUEST = @"SELECT idEmploye,nom,poste,matricule,motPasse "
            + "FROM employe";

        public EmployeDAO()
        {
            connexion = new Connexion();
            command = connexion.Connection.CreateCommand();
        }

        public int Add(EmployeDTO employeDTO)
        {
            int n = 0;
            try
            {
                connexion.Open();
                command.CommandText = ADD_REQUEST;

                command.Parameters.Add(new MySqlParameter("@nom", employeDTO.Nom));
                command.Parameters.Add(new MySqlParameter("@poste", employeDTO.Poste));
                command.Parameters.Add(new MySqlParameter("@matricule", employeDTO.Matricule));
                command.Parameters.Add(new MySqlParameter("@motPasse", employeDTO.MotPasse));
                n = command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException.Message);
            }
            finally
            {
                connexion.Close();
            }
            return n;
        }

        public EmployeDTO Read(int id)
        {
            EmployeDTO employeDTO = new EmployeDTO();
            try
            {
                connexion.Open();
                command.CommandText = READ_REQUEST;

                command.Parameters.Add(new MySqlParameter("@idEmploye", id));
                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    employeDTO.IdEmploye = dr.GetInt32(0);
                    employeDTO.Nom = dr.GetString(1);
                    employeDTO.Poste = dr.GetString(2);
                    employeDTO.Matricule = dr.GetInt32(3);
                    employeDTO.MotPasse = dr.GetString(4);
                }
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException.Message);
            }
            finally
            {
                connexion.Close();
            }
            return employeDTO;
        }

        public int Update(EmployeDTO employeDTO, int id)
        {
            int n = 0;
            try
            {
                connexion.Open();
                command.CommandText = UPDATE_REQUEST;

                command.Parameters.Add(new MySqlParameter("@nom", employeDTO.Nom));
                command.Parameters.Add(new MySqlParameter("@poste", employeDTO.Poste));
                command.Parameters.Add(new MySqlParameter("@matricule", employeDTO.Matricule));
                command.Parameters.Add(new MySqlParameter("@motPasse", employeDTO.MotPasse));
                command.Parameters.Add(new MySqlParameter("@idEmploye", id));
                n = command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException.Message);
            }
            finally
            {
                connexion.Close();
            }
            return n;
        }

        public int Delete(int id)
        {
            int n = 0;
            try
            {
                connexion.Open();
                command.CommandText = DELETE_REQUEST;

                command.Parameters.Add(new MySqlParameter("@idEmploye", id));
                n = command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException.Message);
            }
            finally
            {
                connexion.Close();
            }
            return n;
        }

        public List<EmployeDTO> GetAll()
        {
            List<EmployeDTO> employes = new List<EmployeDTO>();
            EmployeDTO employeDTO = new EmployeDTO();
            try
            {
                connexion.Open();
                command.CommandText = GET_ALL_REQUEST;

                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    employeDTO.IdEmploye = dr.GetInt32(0);
                    employeDTO.Nom = dr.GetString(1);
                    employeDTO.Poste = dr.GetString(2);
                    employeDTO.Matricule = dr.GetInt32(3);
                    employeDTO.MotPasse = dr.GetString(4);
                    employes.Add(employeDTO);
                }
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException.Message);
            }
            finally
            {
                connexion.Close();
            }
            return employes;
        }

    }
}
