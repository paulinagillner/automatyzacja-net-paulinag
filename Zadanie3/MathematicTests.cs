using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Zadanie3
{
    public class MathematicTests//musi być public zeby mozna bylo sie do tego dostac<-nazwa klasy przypadków testowych
     {
        [Theory]//odnosi się tylko do tego co jest do momentu wystapienia pierwszej metody
        [InlineData(10, 20, 30)]                // .
        [InlineData(20, 30, 50)]                // . 
        [InlineData(1, 2, 3)]                   // .
        [InlineData(-0d, 0d, -0d)]              // .
                                                // .
        [                                       // .
            InlineData(0, 0, 0),                // .    //inny sposob na zapisanie
            InlineData(1, 3, 4),                // .
            InlineData(2, 3, 5)                 // .
        ]                                       // .
                                                // .
        [InlineData(0, 0, 0)]                   // v
        public void Method_add_returns_suma_of_given_values(double x, double y, double expected)
        {
            //arrange
            var math = new Matematics();
            //act
            var result = math.Add(x, y);
            //assert 
            Assert.Equal(expected, result);
        }


        [Fact]//po adnotacji Fact jest publiczna klasa, ktora nic nie zwraca
        public void Add_returns_suma_of_given_values()//nie moze nic zwracac, nazwa ma wskazywac co to robi
                   //^-to jest nazwa testu to nam wywali przy podsumowaniu jesli nazwy sa zbyt dlugie i sie zawijaja, to warto sobie stworzyc wiecej kals testowych np dodawanie
        {
            //arrange <-przygotowac srodowisko testowe
            Matematics math = new Matematics();//nazwa () taka sama jak nazwa klasy .cs
            //mozna napisac var math = new Matematics();<- tak samo skompiluje
            //nowy obiekt nie byłby potrzebny jeśli klasa Matematics byłaby static

            //act
            var result = math.Add(10, 20);
            //assert <-określam czego oczekuję, wyniki // sprawdzenie kodu testowanego z tym czego oczekuję
            Assert.Equal(30, result);
        }

        [Fact]
        public void Add_returns_suma2_of_given_values()
        {
            //arrange
            Matematics math = new Matematics();
            //act
            var result = math.Add(10, 5);
            //assert 
            Assert.Equal(15, result);
        }

        [Fact]
        public void Add_returns_roznica_of_given_values()
        {
            //arrange
            Matematics math = new Matematics();
            //act
            var result = math.Substract(30, 5);
            //assert 
            Assert.Equal(25, result);
        }

        [Fact]
        public void Add_returns_roznica2_of_given_values()
        {
            //arrange
            Matematics math = new Matematics();
            //act
            var result = math.Substract(20, 5);
            //assert 
            Assert.Equal(15, result);
        }

        [Fact]
        public void Add_returns_iloczyn_of_given_values()
        {
            //arrange
            Matematics math = new Matematics();
            //act
            var result = math.Multiply(3, 4);
            //assert 
            Assert.Equal(12, result);
        }

        [Fact]
        public void Add_returns_iloczyn2_of_given_values()
        {
            //arrange
            Matematics math = new Matematics();
            //act
            var result = math.Multiply(4, 4);
            //assert 
            Assert.Equal(16, result);
        }

        [Fact]
        public void Add_returns_iloraz01_of_given_values()
        {
            //arrange
            Matematics math = new Matematics();
            //act
            var result = math.Divide(20, 0);
            //assert 
            Assert.Equal(Double.PositiveInfinity , result);
        }
       /* public void Add_returns_iloraz02_of_given_values()
        {
            //arrange
            Matematics math = new Matematics();
            //act
            var result = math.Divide(10, 0);
            //assert 
            //Assert.Throws<DivideByZeroException>(()=>math.Divide()...);

        }*/

        [Fact]
        public void Add_returns_iloraz1_of_given_values()
        {
            //arrange
            Matematics math = new Matematics();
            //act
            var result = math.Divide(10, 5);
            //assert 
            Assert.Equal(2, result);
        }
    }
}
