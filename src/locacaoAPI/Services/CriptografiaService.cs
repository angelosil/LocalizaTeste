using System;
using System.Security.Cryptography;
using System.Text;

namespace locacaoAPI.Services
{
    public class CriptografiaService : ICriptografiaService

    {
        public string CriptografarSenha(string login, string senha)
        {
            // Gera um salt aleatório
            byte[] salt = GerarSalt(login);

            // Converte a senha e o salt para bytes
            byte[] senhaBytes = Encoding.UTF8.GetBytes(senha);
            byte[] senhaComSaltBytes = new byte[senhaBytes.Length + salt.Length];
            Array.Copy(senhaBytes, senhaComSaltBytes, senhaBytes.Length);
            Array.Copy(salt, 0, senhaComSaltBytes, senhaBytes.Length, salt.Length);

            // Calcula o hash usando SHA-256
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(senhaComSaltBytes);

                // Concatena o salt ao hash e converte para base64
                byte[] hashComSaltBytes = new byte[hashBytes.Length + salt.Length];
                Array.Copy(hashBytes, hashComSaltBytes, hashBytes.Length);
                Array.Copy(salt, 0, hashComSaltBytes, hashBytes.Length, salt.Length);

                string hashSenha = Convert.ToBase64String(hashComSaltBytes);
                return hashSenha;
            }
        }

        public byte[] GerarSalt(string username)
        {
            // Utiliza o username para gerar um salt específico
            byte[] usernameBytes = Encoding.UTF8.GetBytes(username);
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(usernameBytes);
            }
        }
    }
}
