namespace Tumakov.Classes
{
    internal class Song
    {
        private string _name;
        private string _author;
        private Song _prev;

        /// <summary> Заполняет поле name </summary>
        /// <param name="name">название песни</param>
        public void SetName(string name)
        {
            _name = name;
        }

        /// <summary> Заполняет поле author </summary>
        /// <param name="author">автор песни</param>
        public void SetAuthor(string author)
        {
            _author = author;
        }

        /// <summary> Заполняет поле prev </summary>
        /// <param name="prev">связь с предыдущей песней в списке</param>
        public void SetPrev(Song prev)
        {
            _prev = prev;
        }

        /// <summary> Выводит информацию о песне </summary>
        /// <returns></returns>
        public string PrintInfo()
        {
            return $"Название: {_name} — Автор: {_author}";
        }

        /// <summary> Сравнение двух песен </summary>
        /// <param name="obj">песня, с которой сравнивается другая</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is not Song other)
            {
                return false;
            }
            return _name == other._name && _author == other._author;
        }
    }
}
