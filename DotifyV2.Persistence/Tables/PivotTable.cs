using System.Data.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using SqlKata.Execution;

namespace DotifyV2.Persistence.Tables
{
    public class PivotTable
    {
        readonly QueryFactory _db;
        readonly string _table;
        readonly string _keyColumnA;
        readonly string _keyColumnB;

        private async Task<bool> DoesRelationExist(int columnA, int columnB)
        {
            var result = await _db.Query(_table)
                .SelectRaw("TRUE")
                .Where(_keyColumnA, columnA)
                .Where(_keyColumnB, columnB)
                .FirstOrDefaultAsync<bool?>();

            return result != null;
        }

        public PivotTable(QueryFactory db, string table, string keyColumnA, string keyColumnB)
        {
            _db = db;
            _table = table;
            _keyColumnA = keyColumnA;
            _keyColumnB = keyColumnB;
        }

        public async Task<bool> InsertAsync(int columnA, int columnB)
        {
            try
            {
                int result = await _db.Query(_table)
                    .InsertAsync(new Dictionary<string, object>
                    {
                    { _keyColumnA, columnA },
                    { _keyColumnB, columnB },
                    });

                return result != 0;
            }
            catch (DbException)
            {
                return await DoesRelationExist(columnA, columnB);
            }
        }

        public async Task<bool> DeleteAsync(int columnA, int columnB)
        {
            if (!await DoesRelationExist(columnA, columnB))
            {
                return true;
            }

            int result = await _db.Query(_table)
                   .Where(_keyColumnA, columnA)
                   .Where(_keyColumnB, columnB)
                   .DeleteAsync();

            return result != 0;
        }

        public Task<IEnumerable<int>> GetAllByAColumn(int columnA)
        {
            return _db.Query(_table)
                .Select(_keyColumnA)
                .Where(_keyColumnA, columnA)
                .GetAsync<int>();
        }

        public Task<IEnumerable<int>> GetAllByBColumn(int columnB)
        {
            return _db.Query(_table)
                .Select(_keyColumnA)
                .Where(_keyColumnB, columnB)
                .GetAsync<int>();
        }
    }
}
