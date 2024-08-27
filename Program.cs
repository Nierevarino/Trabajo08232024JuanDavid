using System;
 
namespace JuegoDeAdivinanzas
 {

    class Juego
    {
    private int numeroSecreto;
    private int intentos;
    public Juego()
        {
            Random random = new Random();
            numeroSecreto = random.Next(1, 11);
            intentos = 0;
        }
 // Método para comenzar el juego
    public void Comenzar()
        {
            Console.WriteLine("¡Bienvenido al juego de adivinanzas!");
            bool adivinado = false;
            while (!adivinado)
            {
                Console.Write("Adivina un número entre 1 y 10: ");
                int numeroUsuario = int.Parse(Console.ReadLine());
                intentos++;
 // Evaluación de la adivinanza
                switch (numeroUsuario)
                {
                    case int n when n == numeroSecreto:
                    Console.WriteLine($"¡Felicidades! Adivinaste el número en {intentos} intentos.");
                    adivinado = true;
                    break;

                    case int n when n < numeroSecreto:
                    Console.WriteLine("El número es mayor.¡Inténtalo de nuevo!");
                    break;

                    case int n when n > numeroSecreto:
                    Console.WriteLine("El número es menor.¡Inténtalo de nuevo!");
                    break;
 
                    default:
                    Console.WriteLine("Número no válido, por favor ingresa un número entre 1 y 10.");
                    break;
                }
            }
        }
    }
 class Program
    {
    static void Main(string[] args)
        {
            Juego juego = new Juego();
            juego.Comenzar();      
        }
    } 
 }


namespace JuegoPokemon
{
    class Pokemon
    {
        public string Nombre { get; set; }
        public int Salud { get; set; }
        public int Ataque { get; set; }
        public int Defensa { get; set; }
 
        public Pokemon(string nombre, int salud, int ataque, int defensa)
        {
            Nombre = nombre;
            Salud = salud;
            Ataque = ataque;
            Defensa = defensa;
        }
        public void Atacar(Pokemon enemigo)
        {
            int daño = Ataque- enemigo.Defensa;
            if (daño < 0) daño = 0;
            enemigo.Salud-= daño;
            Console.WriteLine($"{Nombre} ataca a {enemigo.Nombre} y causa {daño} puntos de daño.");
        }
        public void Defenderse()
        {
            Defensa += 5;
            Console.WriteLine($"{Nombre} se defiende, aumentando su defensa en 5 puntos.");
        }
    }
 
    class Juego
    {
        private Pokemon jugadorPokemon;
        private Pokemon enemigoPokemon;
        public void SeleccionarPokemon()
        {
            Console.WriteLine("Elige tu Pokémon:");
            Console.WriteLine("1. Charmander");
            Console.WriteLine("2. Squirtle");
            Console.WriteLine("3. Bulbasaur");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
                {
                    case 1:
                    jugadorPokemon = new Pokemon("Charmander", 50, 15, 5);
                    break;

                    case 2:
                    jugadorPokemon = new Pokemon("Squirtle", 50, 10, 10);
                    break;

                    case 3:
                    jugadorPokemon = new Pokemon("Bulbasaur", 50, 12, 8);
                    break;
                    default:
                    Console.WriteLine("Opción no válida, elige Charmander por defecto.");
                    jugadorPokemon = new Pokemon("Charmander", 50, 15, 5);
                    break;
                }
            enemigoPokemon = new Pokemon("Pikachu", 50, 14, 6);
            Console.WriteLine($"Has elegido a {jugadorPokemon.Nombre} para la batalla contra {enemigoPokemon.Nombre}.");
        }
        public void Batalla()
        {
            while (jugadorPokemon.Salud > 0 && enemigoPokemon.Salud > 0)
            {
                Console.WriteLine($"\n{jugadorPokemon.Nombre} Salud: {jugadorPokemon.Salud}");
                Console.WriteLine($"{enemigoPokemon.Nombre}- Salud:{enemigoPokemon.Salud}");
                Console.WriteLine("Elige una acción:");
                Console.WriteLine("1. Atacar");
                Console.WriteLine("2. Defenderse");
                int accion = int.Parse(Console.ReadLine());
                switch (accion)
                {
                    case 1:
                    jugadorPokemon.Atacar(enemigoPokemon);
                    break;

                    case 2:
                    jugadorPokemon.Defenderse();
                    break;
                    default:
                    Console.WriteLine("Opción no válida. Perdiste el turno.");
                    break;
                }
                enemigoPokemon.Atacar(jugadorPokemon);
            }
            if (jugadorPokemon.Salud <= 0)
            {
                Console.WriteLine($"¡{jugadorPokemon.Nombre} ha sido derrotado! Has perdido la batalla."); 
            }
            else
            {
                Console.WriteLine($"¡Has derrotado a {enemigoPokemon.Nombre}! ¡Has ganado la batalla!");
            }
        }
    }
    class Program
    {
    static void Main(string[] args)
        {
            Juego juego = new Juego();
            juego.SeleccionarPokemon();
            juego.Batalla();
        }
    }
}

