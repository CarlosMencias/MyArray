using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArray.Logic
{
    public class Arreglos
    {
        private int[] _array;
        private int _top;

        public Arreglos(int n)
        {
            _array = new int[n]; // 10 posiciones
            _top = 0;
            N = n;
        }

        public int N { get; } // Lectura

        public bool IsFull => _top == N; // El arreglo esta lleno
        public bool IsEmpty => _top == 0; // El arreglo esta vacio

        public void Fill(int minimo, int maximo)
        {
            Random random = new Random();
            for (int contador = 0; contador < N; contador++)
            {
                _array[contador] = random.Next(minimo, maximo);
            }
            _top = N;
        }

        
        public Arreglos Primos()
        {
            int countPrimo = 0;
            for (int i = 0; i < _top; i++)
            {
                if (IsPrimo(_array[i]))
                {
                    countPrimo++;
                }
            }
            var getPrimo = new Arreglos(countPrimo);
            for (int i = 0; i < _top; i++)
            {
                if (IsPrimo(_array[i]))
                {
                    getPrimo.Add(_array[i]);
                }
            }
            return getPrimo;
        }

        public Arreglos Pares()
        {
            int countPar = 0;
            for (int i = 0; i < _top; i++)
            {
                if (_array[i] % 2 == 0)
                {
                    countPar++;
                }
            }
            var getPares = new Arreglos(countPar);
            for (int i = 0; i < _top; i++)
            {
                if (_array[i] % 2 == 0)
                {
                    getPares.Add(_array[i]);
                }
            }
            return getPares;
        }

        public Arreglos MoreNumberRepit()
        {

            int[,] matrixCount = new int[_top, 2];
            int topeMatriz = 0;

            // Fill matriz
            for (int i = 0; i < _top; i++)
            {
                int j = 0;
                for (; j < topeMatriz; j++)
                {
                    if(_array[i] == matrixCount[j, 0]) 
                    {
                        matrixCount[j, 1]++;
                        break;
                    }
                }
                if (j == topeMatriz)
                {
                    matrixCount[j, 0] = _array[i];
                    matrixCount[j, 1] = 1;
                    topeMatriz++;
                }
            }

            // Sort Matriz

            for (int i = 0; i < topeMatriz - 1; i++)
            {
                for (int j = i + 1; j < topeMatriz; j++)
                {
                    if (matrixCount[i, 1] < matrixCount[j, 1])
                    {
                        Change(ref matrixCount[i, 0], ref matrixCount[j, 0]);
                        Change(ref matrixCount[i, 1], ref matrixCount[j, 1]);
                    }
                }
            }

            // More number repet

            var countRepet = 1;
            for (int i = 0; i < topeMatriz; i++)
            {
                if (matrixCount[0, 1] == matrixCount[i + 1 , 1])
                {
                    countRepet++;
                }
            }

            var moreRepetNumber = new Arreglos(countRepet);

            for (int i = 0; i < countRepet; i++)
            {
                moreRepetNumber.Add(matrixCount[i, 0]);
            }

            return moreRepetNumber;
        }


        // Números no repetidos
        public Arreglos NotRepetidos()
        {
            int countNotRepeat = 0;
            for (int i = 0; i < _top; i++)
            {
                bool IsRepeat = false;
                for (int j = 0; j < _top; j++)
                {
                    if (i != j)
                    {
                        if (_array[i] == _array[j])
                        {
                            IsRepeat = true;
                            break;
                        }
                    }
                }
                if (!IsRepeat)
                {
                    countNotRepeat++;
                }
            }

            var nonRepeat = new Arreglos(countNotRepeat);
            for (int i = 0; i < _top; i++)
            {
                bool IsRepeat = false;
                for (int j = 0; j < _top; j++)
                {
                    if (i != j)
                    {
                        if (_array[i] == _array[j])
                        {
                            IsRepeat = true;
                            break;
                        }
                    }
                }
                if (!IsRepeat)
                {
                    nonRepeat.Add(_array[i]);
                }
            }
            return nonRepeat;
        }


        // Sort descendente
        public void Sort()
        {
            Sort(false);

        }

        // Ordenamiento ( metodo de burbuja)
        public void Sort(bool desc)
        {
            for (int i = 0; i < _top - 1; i++)
            {
                for (int j = i + 1; j < _top; j++)
                {
                    if (desc)
                    {
                        if (_array[i] < _array[j])
                        {
                            Change(ref _array[i], ref _array[j]);
                        }
                    }
                    else
                    {
                        if (_array[i] > _array[j])
                        {
                            Change(ref _array[i], ref _array[j]);
                        }
                    }
                }
            }
        }

        public void Add(int n)
        {
            if (IsFull)
            {
                throw new Exception("This array is full");
            }
            _array[_top] = n;
            _top++;
        }

        public void Insert(int position, int number)
        {
            if (IsFull)
            {
                throw new Exception("This array is full");
            }

            if (position < 0) position = 0;
            if (position > _top) position = _top;

            for (int i = _top; i > position; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[position] = number;
            _top++;
        }
        public override string ToString()
        {
            string output = string.Empty;
            int count = 0;
            for (int i = 0; i < _top; i++)
            {
                if (count > 9)
                {
                    output += "\n";
                    count = 0;
                }
                output += $"{_array[i]}\t";
                count++;
            }
            return output;
        }

        private void Change(ref int a, ref int b)
        {
            var aux = a;
            a = b;
            b = aux;
        }
        private bool IsPrimo(int n)
        {
            if (n == 1) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}