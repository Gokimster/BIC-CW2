namespace BIC_CW2
{
    class Program
    {
        static void Main(string[] args)
        {
            //MLP mlp = new MLP("1in_linear", -5, 5);
            EvolutionMgr m  = new EvolutionMgr("2in_complex", true, false, 50, 20, 0.4, 0.5, -5, 5);
            m.run();
            //MLP mlp0B = new MLP("1in_linear", -5, 5);
            //MLP mlp1 = new MLP("1in_sine", -5, 5);
            //MLP mlp2 = new MLP("1in_tanh", -5, 5);
            //MLP mlp3 = new MLP("2in_complex", -5, 5);
            //MLP mlp4 = new MLP("2in_xor", -5, 5);
        }
    }
}
