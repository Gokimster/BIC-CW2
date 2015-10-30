namespace BIC_CW2
{
    class Program
    {
        static void Main(string[] args)
        {
            MLP mlp = new MLP("1in_cubic");
            MLP mlp0B = new MLP("1in_linear");
            MLP mlp1 = new MLP("1in_sine");
            MLP mlp2 = new MLP("1in_tanh");
            MLP mlp3 = new MLP("2in_complex");
            MLP mlp4 = new MLP("2in_xor");
        }
    }
}
