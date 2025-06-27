namespace renaissanceproject2025
{
    /// <summary>
    /// Représente un élément de liste avec un texte et une valeur entière.
    /// Utilisé pour les ComboBox, CheckedListBox, etc.
    /// </summary>
    public class ListItem
    {
        /// <summary>
        /// Texte à afficher (ex. : nom de matériel ou fournisseur)
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Identifiant associé (ex. : Id de la base de données)
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Constructeur principal de ListItem
        /// </summary>
        /// <param name="text">Texte à afficher</param>
        /// <param name="value">Identifiant numérique</param>
        public ListItem(string text, int value)
        {
            Text = text;
            Value = value;
        }
        
        /// <summary>
        /// Représente le texte lors de l'affichage dans les listes
        /// </summary>
        /// <returns>Le texte du ListItem</returns>
        public override string ToString()
        {
            return Text;
        }
    }
}
