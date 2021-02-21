using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Класс, описывающий односвязный список.
    /// </summary>
    /// <typeparam name="T">
    /// Тип хранимых данных. 
    /// </typeparam>
    public class LinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Голова списка.
        /// </summary>
        private Node<T> _head = null;

        /// <summary>
        /// Хвост списка. 
        /// </summary>
        private Node<T> _tail = null;

        /// <summary>
        /// Количество узлов списка.
        /// </summary>
        private int _count = 0;

        /// <summary>
        /// Получение доступа к количеству узлов списка.
        /// </summary>
        public int Count
        {
            get
            {
                return _count;
            } 
        }

        /// <summary>
        /// Добавить данные в связный список.
        /// </summary>
        /// <param name="data"> 
        /// Данные узла.
        /// </param>
        public void Add(T data)
        {
            // Проверка входных аргументов на null.
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            // Создание нового узла списка.
            var node = new Node<T>(data);

            // Если связный список пуст, то добавляем созданный узел в начало,
            // иначе добавляем этот узел как следующий за крайним узлом.
            if (_head == null)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;
            }

            // Устанавливаем этот узел последним.
            _tail = node;

            // Увеличиваем счетчик количества узлов списка.
            _count++;
        }

        /// <summary>
        /// Удаление узла из списка.
        /// </summary>
        /// <param name="data"> 
        /// Данные узла.
        /// </param>
        public void Delete(T data)
        {
            // Проверка входных аргументов на null.
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            // Текущий обозреваемый узел списка.
            var current = _head;

            // Предыдущий узел списка, перед обозреваемым.
            Node<T> previous = null;

            // Выполняем переход по всем узлам списка до его завершения,
            // или пока не будет найден узел, который необходимо удалить.
            while (current != null)
            {
                // Если данные обозреваемого узла совпадают с данными из аргумента,
                // то выполняем удаление текущего узла учитывая его положение в списке.
                if (current.Data.Equals(data))
                {
                    // Если узел находится в середине или в конце списка,
                    // удаляем текущий узел из списка.
                    // Иначе это первый узел списка,
                    // удаляем первый узел из списка.
                    if (previous != null)
                    {
                        // Устанавливаем у предыдущего узла указатель на следующий узел от текущего.
                        previous.Next = current.Next;

                        // Если это был последний узел списка, 
                        // то изменяем указатель на крайний узел списка.
                        if (current.Next == null)
                        {
                            _tail = previous;
                        }
                    }
                    else
                    {
                        // Устанавливаем головной узел следующим.
                        _head = _head.Next;

                        // Если список оказался пустым,
                        // то обнуляем и крайний узел.
                        if (_head == null)
                        {
                            _tail = null;
                        }
                    }

                    // Узел был удален.
                    // Уменьшаем количество узлов и выходим из цикла.
                    _count--;
                    break;
                }

                // Переходим к следующему узлу списка.
                previous = current;
                current = current.Next;
            }
        }

        /// <summary>
        /// Удаление по индексу.
        /// </summary>
        /// <param name="delindex">
        /// Индекс узла для удаления.
        /// </param>
        public void DeleteIndex(int delindex)
        {
            int index = 0;

            // Текущий обозреваемый узел списка.
            var current = _head;

            // Предыдущий узел списка, перед обозреваемым.
            Node<T> previous = null;

            // Выполняем переход по всем узлам списка до его завершения,
            // или пока не будет найден узел, который необходимо удалить.
            while (current != null)
            {
                // Если данные обозреваемого узла совпадают с данными из аргумента,
                // то выполняем удаление текущего узла учитывая его положение в списке.
                if (index == delindex)
                {
                    // Если узел находится в середине или в конце списка,
                    // удаляем текущий узел из списка.
                    // Иначе это первый узел списка,
                    // удаляем первый узел из списка.
                    if (previous != null)
                    {
                        // Устанавливаем у предыдущего узла указатель на следующий узел от текущего.
                        previous.Next = current.Next;

                        // Если это был последний узел списка, 
                        // то изменяем указатель на крайний узел списка.
                        if (current.Next == null)
                        {
                            _tail = previous;
                        }
                    }
                    else
                    {
                        // Устанавливаем головной узел следующим.
                        _head = _head.Next;

                        // Если список оказался пустым,
                        // то обнуляем и крайний узел.
                        if (_head == null)
                        {
                            _tail = null;
                        }
                    }

                    // Узел был удален.
                    // Уменьшаем количество узлов и выходим из цикла.
                    _count--;
                    break;
                }

                // Переходим к следующему узлу списка.
                previous = current;
                current = current.Next;
                index++;
            }
        }

        /// <summary>
        /// Редактирование узла списка.
        /// </summary>
        /// <param name="data">
        /// Старые данные узла.
        /// </param>
        /// <param name="newdata">
        /// Новые данные узла.
        /// </param>
        public void Edit(T data, T newdata)
        {
            // Проверка входных аргументов на null.
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            // Проверка входных аргументов на null.
            if (newdata == null)
            {
                throw new ArgumentNullException(nameof(newdata));
            }

            // Текущий обозреваемый узел списка.
            var current = _head;

            // Предыдущий узел списка, перед обозреваемым.
            Node<T> previous = null;

            // Выполняем переход по всем узлам списка до его завершения,
            // или пока не будет найден узел, который необходимо редактировать.
            while (current != null)
            {
                // Если данные обозреваемого узла совпадают с данными из аргумента,
                // то выполняем редактирование текущего узла учитывая его положение в списке.
                if (current.Data.Equals(data))
                {
                    // Записываем новые данные и выходим из цикла
                    current.Data = newdata;
                    break;
                }

                // Переходим к следующему узлу списка.
                previous = current;
                current = current.Next;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="delindex">
        /// Индекс узла для удаления.
        /// </param>
        /// <param name="newdata">
        /// Новые данные узла.
        /// </param>
        public void EditIndex(int delindex, T newdata)
        {
            int index = 0;

            // Проверка входных аргументов на null.
            if (newdata == null)
            {
                throw new ArgumentNullException(nameof(newdata));
            }

            // Текущий обозреваемый узел списка.
            var current = _head;

            // Предыдущий узел списка, перед обозреваемым.
            Node<T> previous = null;

            // Выполняем переход по всем узлам списка до его завершения,
            // или пока не будет найден узел, который необходимо редактировать.
            while (current != null)
            {
                // Если данные обозреваемого узла совпадают с данными из аргумента,
                // то выполняем редактирование текущего узла учитывая его положение в списке.
                if (index == delindex)
                {
                    // Записываем новые данные и выходим из цикла
                    current.Data = newdata;
                    break;
                }

                // Переходим к следующему узлу списка.
                previous = current;
                current = current.Next;
                index++;
            }
        }
        /// <summary>
        /// Очистить список.
        /// </summary>
        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        /// <summary>
        /// Вернуть перечислитель, выполняющий перебор всех узлов в списке.
        /// </summary>
        /// <returns> 
        /// Перечислитель, который можно использовать для итерации по коллекции. 
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            // Перебираем все узлы списка, для представления в виде коллекции элементов.
            var current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        /// <summary>
        /// Вернуть перечислитель, который осуществляет итерационный переход по списку.
        /// </summary>
        /// <returns> 
        /// Объект IEnumerator, который используется для прохода по коллекции. 
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            // Просто возвращаем перечислитель, определенный выше.
            // Это необходимо для реализации интерфейса IEnumerable
            // чтобы была возможность перебирать узлы списка операцией foreach.
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
