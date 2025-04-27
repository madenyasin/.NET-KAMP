namespace WebApplication1.Abstracts
{
    public interface ICrud<TEntity> where TEntity : class
    {
        void Ekle(TEntity entity);
        void Guncelle(TEntity entity);
        void Sil(int id);
        TEntity Bul(int id);
        List<TEntity> Listele();
        IQueryable<TEntity> ListeleQueryable();

    }
}
