using System;
using System.Data.SQLite;
using System.Data;
using System.IO;

namespace off
{
    public class Item
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public string Tipo { get; set; }
    }
    public class OrcamentoItem
    {
        public int Codigo { get; set; }
        public string NomeCliente { get; set; }

        public double ValorTotal { get; set; }
        public DateTime Data { get; set; }


    }

    public class db
    {
        static string nomeArquivoBancoDados = "meu_banco_de_dados.db";
        static void CriarTabelas(SQLiteConnection connection)
        {
            string query = @"
            CREATE TABLE IF NOT EXISTS Estoque (
                Codigo INTEGER PRIMARY KEY AUTOINCREMENT,
                Nome TEXT,
                Valor REAL,
                Tipo TEXT
            );

            CREATE TABLE IF NOT EXISTS Orcamento (
                Codigo INTEGER PRIMARY KEY AUTOINCREMENT,
                NomeCliente TEXT,
                ValorTotal REAL,
                Data DATE
            );";

            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void InsertEstoqueItem(Item item)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={nomeArquivoBancoDados};Version=3;"))
            {
                CriarTabelas(connection);

                connection.Open();
                string query = "INSERT INTO Estoque (Nome, Valor, Tipo) VALUES (@Nome, @Valor, @Tipo);";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", item.Nome);
                    command.Parameters.AddWithValue("@Valor", item.Valor);
                    command.Parameters.AddWithValue("@Tipo", item.Tipo);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
        public static void InsertOrcamentoItem(OrcamentoItem item)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={nomeArquivoBancoDados};Version=3;"))
            {
                CriarTabelas(connection);

                connection.Open();
                string query = "INSERT INTO Orcamento (NomeCliente, ValorTotal, Data) VALUES (@NomeCliente, @ValorTotal, @Data);";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NomeCliente", item.NomeCliente);
                    command.Parameters.AddWithValue("@ValorTotal", item.ValorTotal);
                    command.Parameters.AddWithValue("@Data", item.Data);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
        public static Item getItemByName(string nome)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={nomeArquivoBancoDados};Version=3;"))
            {
                CriarTabelas(connection);

                connection.Open();
                string query = "SELECT * FROM Estoque WHERE Nome = @Nome;"; // Atualize para a tabela correta (Estoque)

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nome);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Item
                            {
                                Codigo = Convert.ToInt32(reader["Codigo"]),
                                Nome = reader["Nome"].ToString(),
                                Valor = Convert.ToDouble(reader["Valor"]),
                                Tipo = reader["Tipo"].ToString()
                            };
                        }
                    }
                }

                connection.Close();
            }

            return null;
        }
        public static List<Item> GetEstoqueItens()
        {
            List<Item> itens = new List<Item>();

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={nomeArquivoBancoDados};Version=3;"))
            {
                CriarTabelas(connection);

                connection.Open();
                string query = "SELECT * FROM Estoque;";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item = new Item
                            {
                                Codigo = Convert.ToInt32(reader["Codigo"]),
                                Nome = reader["Nome"].ToString(),
                                Valor = Convert.ToDouble(reader["Valor"]),
                                Tipo = reader["Tipo"].ToString()
                            };
                            itens.Add(item);
                        }
                    }
                }

                connection.Close();
            }

            return itens;
        }
        public static List<OrcamentoItem> GetOrcamentoItens()
        {
            List<OrcamentoItem> itens = new List<OrcamentoItem>();

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={nomeArquivoBancoDados};Version=3;"))
            {
                CriarTabelas(connection);

                connection.Open();
                string query = "SELECT * FROM Orcamento;";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrcamentoItem item = new OrcamentoItem
                            {
                                Codigo = Convert.ToInt32(reader["Codigo"]),
                                NomeCliente = reader["NomeCliente"].ToString(),
                                ValorTotal = Convert.ToDouble(reader["ValorTotal"])
                            };
                            itens.Add(item);
                        }
                    }
                }

                connection.Close();
            }

            return itens;
        }
        static void CriarTabelaConfiguracoes(SQLiteConnection connection)
        {
            string query = @"
             CREATE TABLE IF NOT EXISTS Configuracoes (
                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                SelectedFolderPath TEXT
            );";

            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static string GetSelectedFolderPath()
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={nomeArquivoBancoDados};Version=3;"))
            {
                CriarTabelaConfiguracoes(connection);

                connection.Open();
                string query = "SELECT SelectedFolderPath FROM Configuracoes ORDER BY ID DESC LIMIT 1;";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return result.ToString();
                    }
                }

                connection.Close();
            }

            return string.Empty;
        }
        public static void UpdateSelectedFolderPath(string selectedFolderPath)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={nomeArquivoBancoDados};Version=3;"))
            {
                CriarTabelaConfiguracoes(connection);

                connection.Open();
                string query = "INSERT OR REPLACE INTO Configuracoes (SelectedFolderPath) VALUES (@SelectedFolderPath);";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SelectedFolderPath", selectedFolderPath);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
        public static List<Item> searchItemsByName(string nome)
        {
            List<Item> resultados = new List<Item>();

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={nomeArquivoBancoDados};Version=3;"))
            {
                CriarTabelas(connection);

                connection.Open();
                string query = "SELECT * FROM Estoque WHERE Nome LIKE @Nome;"; // Usar a cláusula LIKE para busca aproximada

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", $"%{nome}%"); // Adicionar os caracteres curinga % para busca aproximada

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item = new Item
                            {
                                Codigo = Convert.ToInt32(reader["Codigo"]),
                                Nome = reader["Nome"].ToString(),
                                Valor = Convert.ToDouble(reader["Valor"]),
                                Tipo = reader["Tipo"].ToString()
                            };
                            resultados.Add(item);
                        }
                    }
                }

                connection.Close();
            }

            return resultados;
        }
        public static List<OrcamentoItem> searchOrcamentoItemsByName(string nome)
        {
            List<OrcamentoItem> orcamentoItens = new List<OrcamentoItem>();

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={nomeArquivoBancoDados};Version=3;"))
            {
                CriarTabelas(connection);

                connection.Open();
                string query = "SELECT * FROM Orcamento WHERE NomeCliente LIKE @Nome;"; // Use LIKE para pesquisa aproximada

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", "%" + nome + "%"); // Adicione % para pesquisa aproximada

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrcamentoItem item = new OrcamentoItem
                            {
                                Codigo = Convert.ToInt32(reader["Codigo"]),
                                NomeCliente = reader["NomeCliente"].ToString(),
                                ValorTotal = Convert.ToDouble(reader["ValorTotal"]),
                                Data = Convert.ToDateTime(reader["Data"])
                            };
                            orcamentoItens.Add(item);
                        }
                    }
                }

                connection.Close();
            }

            return orcamentoItens;
        }

        public static double CalcularTotalOrcamentos()
        {
            double total = 0;

            List<OrcamentoItem> orcamentoItens = GetOrcamentoItens();

            foreach (OrcamentoItem item in orcamentoItens)
            {
                total += item.ValorTotal;
            }

            return total;
        }
        public static int CalcularOrcamentos()
        {
            List<OrcamentoItem> orcamentoItens = GetOrcamentoItens();
            return orcamentoItens.Count;
        }
        //TODO: Implementar função de calcular quantidade em cada tabela, de estoque e de orçamento.
    }
}
