using Dapper;
using System.Data;
using System.Data.SqlClient;
using WebApi05.Data;
using WebApi05.Models;

namespace WebApi05.Service
{
    public interface IStudentsRepository
    {
        Task<IEnumerable<Students>> GetAllStudents();
        Task<Students> InserUpdateStudents(Students model);

        Task<bool> DeleteStudents(Guid Id);


    }
    public class StudentsRepository : IStudentsRepository
    {
        private readonly SqlConnections connection;
        public StudentsRepository(SqlConnections connection)
        {
            this.connection = connection;
        }

       

       async Task<bool> IStudentsRepository.DeleteStudents(Guid Id)
        {
            using var dbconnect = await connection.CreateConnectionAsync(connection);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            return await dbconnect.QueryFirstOrDefaultAsync<bool>("DeleteStudents", parameters, commandType: CommandType.StoredProcedure);
        }

       
        async Task<IEnumerable<Students>> IStudentsRepository.GetAllStudents()
        {
            using var emp = await connection.CreateConnectionAsync(connection);
            return await emp.QueryAsync<Students>("EXEC GetAllStudents");

        }


        async Task<Students> IStudentsRepository.InserUpdateStudents(Students model)
        {
           using var dbConnect=await connection.CreateConnectionAsync(connection);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id",model.Id== Guid.Empty?Guid.NewGuid():model.Id);
            parameters.Add("@Name", model.Name);
            parameters.Add("@Department", model.Department);
            parameters.Add("@Phone", model.Phone);
            parameters.Add("@Email",model.Email);

            return await dbConnect.QuerySingleOrDefaultAsync<Students>("InserUpdateStudents",parameters,commandType:CommandType.StoredProcedure);



                }

        
    }
}
