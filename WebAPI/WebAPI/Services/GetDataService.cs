using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class GetDataService : GetDataInterface, FormSubmitInterface
    {
        private static List<Ksiazka> repository = [
            new Ksiazka() { Id = 1, Tytul = "Książka 1", Cena = 100, DataWydania = new DateOnly(2020, 1, 1) },
            new Ksiazka() { Id = 2, Tytul = "Książka 2", Cena = 200, DataWydania = new DateOnly(2021, 1, 1) },
            new Ksiazka() { Id = 3, Tytul = "Książka 3", Cena = 300, DataWydania = new DateOnly(2022, 1, 1) },
            new Ksiazka() { Id = 4, Tytul = "Książka 4", Cena = 400, DataWydania = new DateOnly(2023, 1, 1) },
            new Ksiazka() { Id = 5, Tytul = "Książka 5", Cena = 500, DataWydania = new DateOnly(2024, 1, 1) },
        ];

        public Task<bool> AddAsync(KsiazkaDTO ksiazkaDto)
        {
            var newKsiazka = new Ksiazka
            {
                Id = repository.Max(x => x.Id) + 1,
                Tytul = ksiazkaDto.Tytul,
                Cena = ksiazkaDto.Cena,
                DataWydania = ksiazkaDto.DataWydania
            };
            repository.Add(newKsiazka);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<KsiazkaDTO>> GetAsync()
        {
            var res = repository.Select(x => KsiazkaToDTO(x));
            return Task.FromResult(res);
        }

        public Task<KsiazkaDTO?> GetAsyncByID(int id)
        {
            Ksiazka? obj = repository.Find(x => x.Id == id);
            KsiazkaDTO? res;
            if (obj == null)
            {
                res = null;
            }
            else 
            {
                res = KsiazkaToDTO(obj);
            }
            return Task.FromResult(res);
        }

        public Task<bool> UpdateAsync(int id, KsiazkaDTO ksiazkaDto)
        {
            var existing = repository.Find(x => x.Id == id);
            if (existing == null)
                return Task.FromResult(false);

            existing.Tytul = ksiazkaDto.Tytul;
            existing.Cena = ksiazkaDto.Cena;
            existing.DataWydania = ksiazkaDto.DataWydania;
            return Task.FromResult(true);
        }

        private KsiazkaDTO KsiazkaToDTO(Ksiazka ksiazka)
        {
            return new KsiazkaDTO(ksiazka.Id, ksiazka.Tytul, ksiazka.Cena, ksiazka.DataWydania);
        }
    }
}
