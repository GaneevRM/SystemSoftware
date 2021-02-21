using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Класс, описывающий узел односвязного списка.
    /// </summary>
    /// <typeparam name="T"> 
    /// Тип хранимых данных. 
    /// </typeparam>

    public class Node<T>
    {
            /// <summary>
            /// Данные узла.
            /// </summary>
            public T Data { get; set; }

            /// <summary>
            /// Следующий узел списка.
            /// </summary>
            public Node<T> Next { get; set; }

            /// <summary>
            /// Создание нового узла списка.
            /// </summary>
            /// <param name="data">
            /// Данные узла.
            /// </param>
            public Node(T data)
            {
                // Проверка входных аргументов на null.
                if (data == null)
                {
                    throw new ArgumentNullException(nameof(data));
                }

                Data = data;
            }

            /// <summary>
            /// Приведение объекта к типу string.
            /// </summary>
            /// <returns> 
            /// Данные узла. 
            /// </returns>
            public override string ToString()
            {
                return Data.ToString();
            }
        
    }
}
