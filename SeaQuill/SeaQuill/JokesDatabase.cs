using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace SeaQuill
{
    public class JokesDatabase
    {
        private static readonly Lazy<SQLiteAsyncConnection> LazyInitializer =
            new Lazy<SQLiteAsyncConnection>(() => new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags));

        private static SQLiteAsyncConnection Database => LazyInitializer.Value;
        private static bool _initialized;

        public JokesDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        private async Task InitializeAsync()
        {
            if (!_initialized)
            {
                if (Database.TableMappings.All(m => m.MappedType.Name != nameof(Joke)))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Joke)).ConfigureAwait(false);
                    _initialized = true;
                }
            }
        }

        public Task<List<Joke>> GetJokesAsync()
        {
            return Database.Table<Joke>().ToListAsync();
        }

        public Task<int> SaveJokeAsync(Joke joke)
        {
            return Database.InsertAsync(joke);
        }

    }
}