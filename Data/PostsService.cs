using Microsoft.EntityFrameworkCore;

namespace AgendaPsi.Data;

public class PostsService
{
    #region Métodos privados

    private ApplicationDbContext dbContext;

    #endregion

    #region Construtor

    public PostsService(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    #endregion

    #region Metodos Publicos

    // ... outros membros da classe

    /// <summary>
    /// Retorna um post com base no ID fornecido.
    /// </summary>
    /// <param name="postId">O ID do post a ser retornado.</param>
    /// <returns>O post correspondente ao ID ou null se não for encontrado.</returns>
    public async Task<Posts> GetPostByIdAsync(int postId)
    {
        return await dbContext.Posts.FirstOrDefaultAsync(p => p.Id == postId);
    }

    /// <summary>
    /// Retorna a lista de posts
    /// </summary>
    /// <returns></returns>
    public async Task<List<Posts>> RetornaPostAsync()
    {
        return await dbContext.Posts.ToListAsync();
    }

    /// <summary>
    /// Adiciona um novo post para DbContext e o salva
    /// </summary>
    /// <param name="post"></param>
    /// <returns></returns>
    public async Task<Posts> AddPostAsync(Posts post)
    {
        dbContext.Posts.Add(post);
        await dbContext.SaveChangesAsync();
        return post;
    }

    /// <summary>
    /// Atualiza um post e salva as mudanças
    /// </summary>
    /// <param name="post"></param>
    /// <returns></returns>
    public async Task<Posts> UpdatePostAsync(Posts post)
    {
        var postExists = dbContext.Posts.FirstOrDefault(p => p.Id == post.Id);
        if (postExists != null)
        {
            dbContext.Update(post);
            await dbContext.SaveChangesAsync();
        }

        return post;
    }

    /// <summary>
    /// Remove um post de DbContext e o salva
    /// </summary>
    /// <param name="post"></param>
    /// <returns></returns>
    public async Task DeletePostAsync(Posts post)
    {
        dbContext.Posts.Remove(post);
        await dbContext.SaveChangesAsync();
    }

    #endregion
}