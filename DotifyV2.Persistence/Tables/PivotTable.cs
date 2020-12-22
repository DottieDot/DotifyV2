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

        public PivotTable(QueryFactory db, string table, string keyColumnA, string keyColumnB)
        {
            _db = db;
            _table = table;
            _keyColumnA = keyColumnA;
            _keyColumnB = keyColumnB;
        }

        public async Task<bool> InsertAsync(int columnA, int columnB)
        {
            int result = await _db.Query(_table)
                .InsertAsync(new Dictionary<string, int>
                {
                    { _keyColumnA, columnA },
                    { _keyColumnB, columnB },
                });

            return result != 0;
        }

        public async Task<bool> DeleteAsync(int columnA, int columnB)
        {
            int result = await _db.Query(_table)
                   .Where(_keyColumnA, columnA)
                   .Where(_keyColumnB, columnB)
                   .DeleteAsync();

            return result != 0;
        }
    }
}
