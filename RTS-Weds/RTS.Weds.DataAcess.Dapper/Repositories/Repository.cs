using RTS.Weds.DataAcess.Dapper.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using RTS.Weds.Common;

namespace RTS.Weds.DataAcess.Dapper.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private string _conn = string.Empty;

             
        public Repository()
        {
            _conn = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=RTSWeds;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //_conn= @"Data Source=rtswedsserver.database.windows.net;Initial Catalog=RTSDB;Integrated Security=False;User ID=riyajshaikh09;Password=admin123!@#;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        #region Protected Member(s)

        private static string _DbConnection;
        protected IDbConnection DbConnection
        {
            get
            {
                if (string.IsNullOrEmpty(_DbConnection))
                {
                    _DbConnection = _conn;
                }
                return new SqlConnection(_DbConnection);
            }
        }

        protected IDbConnection GetOpenConnection()
        {
            var connection = new SqlConnection(_conn);
            connection.Open();
            return connection;
        }


        protected virtual object Mapping(TEntity item)
        {
            // Logic to map the Db column to dataModel if needed
            return item;
        }

        #endregion

        #region IRepository Implementation

        /// <summary>
        /// Method to add given entity
        /// </summary>
        /// <param name="item"></param>
        public virtual TEntity Add(TEntity item)
        {
            using (var con = DbConnection)
            {
                con.Insert<TEntity>(item);
            }

            return item;
        }


        public virtual dynamic Add<T>(TEntity item)
        {
            using (var con = DbConnection)
            {
                return con.Insert<TEntity>(item);
            }
        }


        /// <summary>
        /// Method to Find an enity with the given searhc criteria
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual TEntity Find(string Id)
        {
            TEntity item = default(TEntity);

            using (var con = DbConnection)
            {
                item = con.Get<TEntity>(Id);
            }

            return item;
        }

        /// <summary>
        /// Method to Find records based on select predicates
        /// </summary>
        /// <param name="predicateList"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Find(List<IPredicate> predicateList)
        {
            IEnumerable<TEntity> itemList = null;
            var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            pg.Predicates = predicateList;

            using (var con = DbConnection)
            {
                itemList = con.GetList<TEntity>(pg);
            }

            return itemList;
        }

        /// <summary>
        /// Method to Find records based on select predicates
        /// </summary>
        /// <param name="predicateList"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Find(PredicateGroup predicateGroup)
        {
            IEnumerable<TEntity> itemList = null;

            using (var con = DbConnection)
            {
                itemList = con.GetList<TEntity>(predicateGroup);
            }

            return itemList;
        }

        /// <summary>
        /// Method to get all entities
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            IEnumerable<TEntity> item = null;
            using (var con = DbConnection)
            {
                item = con.GetList<TEntity>();

                // TODO : Need to paginate this call
                //con.GetListPaged<TEntity>(1, 1, "", "");
            }
            return item;
        }

        /// <summary>
        /// Method to remove the entity
        /// </summary>
        /// <param name="item"></param>
        public virtual void Remove(TEntity item)
        {
            using (var con = DbConnection)
            {
                con.Delete(item);
            }
        }

        public virtual void Remove(TEntity item, IPredicate predicate)
        {
            using (var con = DbConnection)
            {
                con.Delete<TEntity>(predicate);
            }



        }
        /// <summary>
        /// Method to update the entity
        /// </summary>
        /// <param name="item"></param>
        public virtual void Update(TEntity item)
        {
            using (var con = DbConnection)
            {
                con.Update(item);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual dynamic Update<T>(TEntity item)
        {
            using (var con = DbConnection)
            {
                return con.Update<TEntity>(item);
            }
        }

        /// <summary>
        /// Method to batch/bulk insert/update transaction 
        /// </summary>
        /// <type param name="sqlBatch" ></typeparam>
        /// <param name="param" ></param>
        /// <returns></returns>
        public virtual dynamic BatchCommandQuery(string sqlBatch, object param)
        {

            dynamic result = default(int);
            using (var connection = DbConnection)
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    result = connection.Execute(sqlBatch, param, commandTimeout: transaction.Connection.ConnectionTimeout);
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                return result;
            }

        }


        public IEnumerable<T> GetDataUsingQuery<T>(string SqlQuery)
        {
            IEnumerable<T> item = null;


            using (var con = DbConnection)
            {
                item = con.Query<T>(SqlQuery, commandTimeout: con.ConnectionTimeout);
            }
            return item;

        }

        public IEnumerable<int> GetCloumnDataUsingQuery(string SqlQuery)
        {
            IEnumerable<int> item = null;


            using (var con = DbConnection)
            {
                item = con.Query<int>(SqlQuery, commandTimeout: con.ConnectionTimeout);
            }
            return item;

        }


        public List<IDictionary<string, object>> GetDictionaryDataUsingQuery(string SqlQuery)
        {
            List<IDictionary<string, object>> QueryResultData = new List<IDictionary<string, object>>();

            using (var con = DbConnection)
            {
                var results = con.Query<dynamic>(SqlQuery).ToList();

                foreach (IDictionary<string, object> row in results)
                {
                    QueryResultData.Add(row);

                    // do something with fields["Name"] and fields["Street"]
                }
            }
            return QueryResultData;

        }

        public virtual IEnumerable<T> GetPagedDataUsingQuery<T>(string SqlQuery, int currentPage, int resultPerPage)
        {
            List<T> QueryResultData = new List<T>();

            Sort so = new Sort();
            so.PropertyName = "ProductId";
            so.Ascending = true;
            List<ISort> sort = new List<ISort>();
            sort.Add(so);
            // sort.Add("");
            //IEnumerable<T> results = null;
            using (var con = DbConnection)
            {
                var results = con.GetPage<TEntity>(SqlQuery, sort, currentPage, resultPerPage);

                foreach (IDictionary<string, object> row in results)
                {
                    //  QueryResultData.Add(row);

                    // do something with fields["Name"] and fields["Street"]
                }
            }
            return QueryResultData;

        }

        public int ExecuteQuery(string sqlQuery, object param)
        {
            int result = 0;
            using (var con = DbConnection)
            {
                result = con.Execute(sqlQuery, param);
            }
            return result;
        }

        public IEnumerable<T> RunSP<T>(string sprocName, Dictionary<string, object> parameterCollection)
        {
            IEnumerable<T> result;
            using (var con = DbConnection)
            {
                var parameters = new DynamicParameters();
                foreach (var item in parameterCollection)
                {
                    string paramName = string.Format("@{0}", item.Key.Trim());
                    object paramValue = item.Value;
                    parameters.Add(paramName, paramValue);
                }
                result = con.Query<T>(sprocName, parameters, commandType: CommandType.StoredProcedure, commandTimeout: con.ConnectionTimeout);
            }
            return result;
        }
       

        public dynamic Update<T>(TEntity item, IDbTransaction trans, IDbConnection conn)
        {
            return conn.Update<TEntity>(item, trans);
        }

        public IDbConnection GetConnection()
        {
            return GetOpenConnection();
        }

        public IEnumerable<T> GetDataUsingQueryTransaction<T>(string SqlQuery, IDbTransaction trans, IDbConnection conn)
        {
            IEnumerable<T> item = null;
            item = conn.Query<T>(SqlQuery, null, trans);
            //item = conn.Execute(SqlQuery, trans);

            return item;

        }
       
        #endregion
    }

}
