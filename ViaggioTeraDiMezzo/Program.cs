using System;
using System.ComponentModel.Design;
using System.Data;

namespace ViaggioControBowser
{
    internal class Program
    {
        static void INTRO(string personaggi) //Introduzione al gioco
        {
            Console.WriteLine("SUPER MARIO ODYSSEY");

            Console.WriteLine("Bowser:Troppo tardi," + personaggi + "Ti ho battuto sul tempo! Non importa quanti salti e capriole fai, non potrai mai raggiungere questo aereo.\r\n\r\n" + personaggi + ":Bowser! Lascia andare Peach, immediatamente! La tua pazzia deve finire!\r\n\r\nPeach:" + personaggi + ", non preoccuparti per me! Lui ha barato!\r\n\r\nBowser: Barato? Io la chiamo preparazione meticolosa, cara Principessa. E questa volta, non è un rapimento come gli altri. Questo è... un matrimonio!\r\n\r\n" + personaggi + ": Mamma mia! Un... un cappello da sposa?!\r\n\r\nBowser: Esatto! Ho radunato gli oggetti più sfarzosi e i cuochi migliori dell'intero universo per rendere questo il matrimonio più grandioso che il Regno dei Funghi non vedrà mai! E tu, insignificante idraulico, sei in prima fila... come spettatore della mia vittoria!\r\n\r\n" + personaggi + ": Non accadrà mai! Io ti fermerò! (" + personaggi + " si lancia verso Bowser, ma una barriera di fuoco Koopa lo respinge.)\r\n\r\nBowser: Ah ah ah! Sei stanco e senza forze. E, cosa più importante... sei senza cappello! Senza il tuo cappello portafortuna, sei solo un tipo baffuto in salopette. Addio, " + personaggi + " Divertiti a guardare le mie nozze da sotto!\r\n\r\n" + personaggi + "Non ho ancora finito, Bowser! Tornerò!");

            Console.WriteLine("\r\n\r\n");

        }
        static string Personaggi(ref int Vita, ref int Attacco) //Scelta personaggio
        {
            Console.WriteLine(" ------------------------------------------");
            Console.WriteLine("| Scegli il potagonista della vicenda:     |");
            Console.WriteLine("|                                          |");
            Console.WriteLine("| 1: MARIO.  Punti vita = 10 / Attacco = 2 |");
            Console.WriteLine("|                                          |");
            Console.WriteLine("| 2: LUIGI.  Punti vita = 6 / Attaco = 4   |");
            Console.WriteLine("|                                          |");
            Console.WriteLine(" ------------------------------------------");

            string personaggi = Console.ReadLine();

            if (personaggi == "Mario")
            {
                Vita = 10;
                Attacco = 2;
                Console.WriteLine("Hai scelto Mario come protagonista!");
            }
            else if (personaggi == "Luigi")
            {
                Vita = 6;
                Attacco = 4;
                Console.WriteLine("Hai scelto Luigi come protagonista!");
            }

            INTRO(personaggi);

            Console.WriteLine("Sei nei panni di " + personaggi + ", devi riuscire ad arrivare alla fortezza di Bowser (Bowser's kingdom) e salvare la principessa Peach. Qusto viaggio non sarà facile, ci saranno imprevisti nel mezzo del viaggio che potranno cambiare le sorti dell'avventura, ad accompagnarti c'è cappy, un'alleato di mario che permette a lui di possedere personaggi, nemici e oggetti. Quindi detto ciò buona fortuna...");

            return personaggi;
        }
        static int TurnoDiGioco(int Vita, int Attacco, string personaggi, int PozioneCura, int cavalcatura, int fioreDiFuoco, string[] Mappa) //Menu delle azioni
        {
            Console.WriteLine(" -------------------------------------");
            Console.WriteLine("|   Cosa vuoi fare?                   |");
            Console.WriteLine("|   1. Avanza                         |");
            Console.WriteLine("|   2. Mostra stutus di Mario         |");
            Console.WriteLine("|   3. Mostra inventario di Mario     |");
            Console.WriteLine("|   4. Usa oggetto                    |");
            Console.WriteLine("|   5. Esci dal gioco                 |");
            Console.WriteLine(" -------------------------------------");

            int scelta = Convert.ToInt32(Console.ReadLine());

            return scelta;
        }
        static void InventarioPersonaggio(int PozioneCura, int cavalcatura, int fioreDiFuoco) //Mostra l'inventario
        {
            Console.WriteLine(" ---------------------------");
            Console.WriteLine("|   Inventario di Mario:    |");
            Console.WriteLine("|   Pozione Cura: " + PozioneCura + "          |");
            Console.WriteLine("|   Pezzi di cavalcatura: " + cavalcatura + "   |");
            Console.WriteLine("|   Fiori di fuoco: " + fioreDiFuoco + "        |");
            Console.WriteLine(" ---------------------------");
        }
        static void UsaOggetto(int PozioneCura, int Vita, int Attacco, int fioreDiFuoco, int cavalcatura) //Usa un oggetto
        {
            Console.WriteLine("Quale oggetto vuoi usare?");
            Console.WriteLine("1: Pozione Cura");
            Console.WriteLine("2: cavalcatura");
            Console.WriteLine("3: Fiore di fuoco");
            int sceltaOggetto = Convert.ToInt32(Console.ReadLine());

            if (sceltaOggetto == 1)
            {
                if (PozioneCura > 0)
                {
                    Vita = Vita + 5;
                    PozioneCura--;
                    Console.WriteLine("Hai usato una Pozione Cura, la tua vita è aumentata di 5 punti!");
                }
                else
                {
                    Console.WriteLine("Non hai Pozioni Cura nell'inventario!");
                }
            }
            else if (sceltaOggetto == 2 && cavalcatura >= 2)
            {
                Console.WriteLine("Hai usato una cavalcatura, questa ti permette di avanzare più velocemente tra i vari mondi.");
                cavalcatura = cavalcatura - 2;
            }
            else if (sceltaOggetto == 3 && fioreDiFuoco > 0)
            {
                Console.WriteLine("Hai usato un Fiore di fuoco!");
                Attacco = Attacco + 3;
                fioreDiFuoco--;

            }
        }
        static void StatusPersonaggio(int Vita, int Attacco, string personaggi) //Mostra lo status di mario
        {
            Console.WriteLine(" ---------------------------");
            Console.WriteLine("|   Status di " + personaggi + ":        |");
            Console.WriteLine("|   Vita: " + Vita + "                |");
            Console.WriteLine("|   Attacco: " + Attacco + "              |");
            Console.WriteLine(" ---------------------------");
        }
        static void Fossilandia(string personaggi, int Vita, int Attacco, int PozioneCura, int cavalcatura, int fioreDiFuoco, string[] Mappa) //Prima tappa del viaggio
        {
            string[] Fossilandia = { "Dinosauro", "ChainComp", "MadameBrode" };

            Random rand = new Random();
            Random Fuga = new Random();

            int DinosauroVita = 5, DinosauroAttacco = 2, ChainChompVita = 3, ChainChompAttacco = 1, MadameBroodeVita = 8, MadameBroodeAttacco = 2, p = 0, l = 0;

            for (int i = 0; i < Fossilandia.Length; i++)
            {
                if (i == 0) //Dinosauro
                {
                    Console.WriteLine("Sei entrato in Fossilandia, all'improvviso un Dinosauro ti blocca la strada ma noti una via di fuga!");

                    Console.WriteLine(" Cosa scegli di fare? ");
                    Console.WriteLine(" 1: Affrontare il Dinosauro, con possibile ricompensa ");
                    Console.WriteLine(" 2: Fuggire via dalla via di fuga senza prendere rischi ");
                    string scelta = Console.ReadLine();

                    if (scelta == "1")
                    {
                        Console.WriteLine("Hai deciso di affrontare il Dinosauro!");

                        while (DinosauroVita > 0)
                        {
                            int TiroDado = rand.Next(1, 7);

                            if (TiroDado <= 2)
                            {
                                Console.WriteLine("Valore tiro dado: " + TiroDado);
                                Console.WriteLine("Non sei riuscito ad attaccare il dinosauro, ora lui ti ha attaccato e ti ha inflitto " + DinosauroAttacco + " danni! Premi un tasto per continuare...");
                                Console.ReadLine();
                                Vita -= DinosauroAttacco;
                                StatusPersonaggio(Vita, Attacco, personaggi);
                                Console.WriteLine("La vita del dinosauro è: " + DinosauroVita);

                                if (Vita <= 0)
                                {
                                    Console.WriteLine("GAME OVER. Sei stato sconfitto dal dinosauro, il tuo viaggio finisce qui...                                     Riprovi?");
                                    Environment.Exit(0);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Valore tiro dado: " + TiroDado);
                                Console.WriteLine("Sei riuscito ad attaccare il dinosauro, gli hai inflitto " + Attacco + " danni! Premi un tato per continuare...");
                                Console.ReadLine();
                                DinosauroVita -= Attacco;
                                StatusPersonaggio(Vita, Attacco, personaggi);
                                Console.WriteLine("La vita del dinosauro è: " + DinosauroVita);

                                if (Vita <= 0)
                                {
                                    Console.WriteLine("GAME OVER. Sei stato sconfitto dal dinosauro, il tuo viaggio finisce qui...                                     Riprovi?");
                                    Environment.Exit(0);
                                }
                            }
                        }

                        Console.WriteLine("Sei riuscito a stordire il dinosauro! Come ricompensa per la tua vittoria, ottieni una Pozione Cura!");

                        PozioneCura++;

                        Console.WriteLine("Ora che il dinosauro è stordito puoi usare cappy per possederlo e riuscire a distruggere ed oltrepassare il muro di roccia che ti ostacola");
                        p++;
                    }
                    else if (scelta == "2")//fuga dinosauro
                    {
                        Console.WriteLine("Hai deciso di fuggire via dalla via di fuga!");
                        Console.WriteLine("Puoi fuggire via solo se otterrai un valore superiore a 80 nel tiro del dado!");

                        int TiroDadoFuga = Fuga.Next(1, 101);

                        if (TiroDadoFuga > 80)
                        {
                            Console.WriteLine("Valore tiro dado fuga: " + TiroDadoFuga);
                            Console.WriteLine("Sei riuscito a fuggire via dal dinosauro utilizzando la via di fuga!");
                            l++;
                        }
                        else
                        {
                            Console.WriteLine("Valore tiro dado fuga: " + TiroDadoFuga);
                            Console.WriteLine("Non sei riuscito a fuggire via dal dinosauro, prova ad attaccarlo!");
                            p++;

                            while (DinosauroVita > 0)
                            {
                                int TiroDado2 = rand.Next(1, 7);

                                if (TiroDado2 <= 2)
                                {
                                    Console.WriteLine("Valore tiro dado: " + TiroDado2);
                                    Console.WriteLine("Non sei riuscito ad attaccare il dinosauro, ora lui ti ha attaccato e ti ha inflitto " + DinosauroAttacco + " danni! Premi un tasto per continuare...");
                                    Console.ReadLine();
                                    Vita -= DinosauroAttacco;
                                    StatusPersonaggio(Vita, Attacco, personaggi);
                                    Console.WriteLine("La vita del dinosauro è: " + DinosauroVita);

                                    if (Vita <= 0)
                                    {
                                        Console.WriteLine("GAME OVER. Sei stato sconfitto dal dinosauro, il tuo viaggio finisce qui...                                     Riprovi?");
                                        Environment.Exit(0);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Valore tiro dado: " + TiroDado2);
                                    Console.WriteLine("Sei riuscito ad attaccare il dinosauro, gli hai inflitto " + Attacco + " danni! Premi un tasto per continuare...");
                                    Console.ReadLine();
                                    DinosauroVita -= Attacco;
                                    StatusPersonaggio(Vita, Attacco, personaggi);
                                    Console.WriteLine("La vita del dinosauro è: " + DinosauroVita);

                                    if (Vita <= 0)
                                    {
                                        Console.WriteLine("GAME OVER. Sei stato sconfitto dal dinosauro, il tuo viaggio finisce qui...                                     Riprovi?");
                                        Environment.Exit(0);
                                    }
                                }
                            }

                            Console.WriteLine("Sei riuscito a stordire il dinosauro! Come ricompensa per la tua vittoria, ottieni una Pozione Cura!");

                            PozioneCura++;

                            Console.WriteLine("Ora che il dinosauro è stordito puoi usare cappy per possederlo e riuscire a distruggere ed oltrepassare il muro di roccia che ti ostacola");
                        }
                    }

                }
                else if (i == 1)//chainchomp
                {
                    if (p > 0)
                    {
                        Console.WriteLine("Proseguendo nel tuo cammino, vieni attaccato da una ChainComp, ma visto che sei un dinosauro ti basta fare solo un buon attacco per sconfiggerlo, ti basterà solamente totalizzare un puntaggio maggiore di 3 nel tiro di un dado per riuscire a sconfiggerlo");
                        Console.ReadLine();
                        int TiroDado3 = rand.Next(1, 7);

                        if (TiroDado3 > 3)
                        {
                            Console.WriteLine("Valore tiro dado: " + TiroDado3);
                            Console.WriteLine("Sei riuscito a sconfiggere Chain Chomp! Come ricompensa per la tua vittoria, ottieni un pezzo di cavalcatura!");
                        }
                        else
                        {
                            Console.WriteLine("Valore tiro dado: " + TiroDado3);
                            Console.WriteLine("Non sei riuscito a sconfiggere la ChainComp, ora lui ti ha colpito e sei tornato di nuovo nel corpo di " + personaggi + "! Prova a sconfiggerlo.");

                            while (ChainChompVita > 0)
                            {
                                int TiroDado4 = rand.Next(1, 7);

                                if (TiroDado4 <= 2)
                                {
                                    Console.WriteLine("Valore tiro dado: " + TiroDado4);
                                    Console.WriteLine("Non sei riuscito ad attaccare Chain Chomp, ora lui ti ha attaccato e ti ha inflitto " + DinosauroAttacco + " danni! Premi un tasto per continuare...");
                                    Console.ReadLine();
                                    Vita -= ChainChompAttacco;
                                    StatusPersonaggio(Vita, Attacco, personaggi);
                                    Console.WriteLine("La vita del ChainChomp è: " + ChainChompVita);

                                    if (PozioneCura > 0 && Vita <= 4)
                                    {
                                        Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                                        string sceltaPozione = Console.ReadLine();
                                        if (sceltaPozione == "si")
                                        {
                                            Vita += 5;
                                            PozioneCura--;
                                            Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                                        }
                                    }

                                    if (Vita <= 0)
                                    {
                                        Console.WriteLine("GAME OVER. Sei stato sconfitto da ChainChomp, il tuo viaggio finisce qui...                                     Riprovi?");
                                        Environment.Exit(0);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Valore tiro dado: " + TiroDado4);
                                    Console.WriteLine("Sei riuscito ad attaccare Chain Chomp, gli hai inflitto " + Attacco + " danni! Premi un tato per continuare...");
                                    Console.ReadLine();
                                    ChainChompVita -= Attacco;
                                    StatusPersonaggio(Vita, Attacco, personaggi);
                                    Console.WriteLine("La vita del ChainChomp è: " + ChainChompVita);

                                    if (PozioneCura > 0 && Vita <= 4)
                                    {
                                        Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                                        string sceltaPozione = Console.ReadLine();
                                        if (sceltaPozione == "si")
                                        {
                                            Vita += 5;
                                            PozioneCura--;
                                            Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                                        }
                                    }

                                    if (Vita <= 0)
                                    {
                                        Console.WriteLine("GAME OVER. Sei stato sconfitto da ChainChomp, il tuo viaggio finisce qui...                                     Riprovi?");
                                        Environment.Exit(0);
                                    }
                                }
                            }

                            Console.WriteLine("Sei riuscito a sconfiggere Chain Chomp! Come ricompensa per la tua vittoria, ottieni un pezzo di cavalcatura!");
                            cavalcatura++;
                        }

                    }
                    else if (l > 0)
                    {
                        Console.WriteLine("Proseguendo nel tuo cammino, vieni attaccato da una ChainComp! Una palla di ferro legata a terra da una catena. Attaccala per continuare il viaggio.");

                        while (ChainChompVita > 0)
                        {
                            int TiroDado = rand.Next(1, 7);

                            if (TiroDado <= 2)
                            {
                                Console.WriteLine("Valore tiro dado: " + TiroDado);
                                Console.WriteLine("Non sei riuscito ad attaccare il ChainChomp, ora lui ti ha attaccato e ti ha inflitto " + ChainChompAttacco + " danni! Premi un tasto per continuare...");
                                Console.ReadLine();
                                Vita -= ChainChompAttacco;
                                StatusPersonaggio(Vita, Attacco, personaggi);
                                Console.WriteLine("La vita del ChainChomp è: " + ChainChompVita);

                                if (PozioneCura > 0 && Vita <= 4)
                                {
                                    Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                                    string sceltaPozione = Console.ReadLine();
                                    if (sceltaPozione == "si")
                                    {
                                        Vita += 5;
                                        PozioneCura--;
                                        Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                                    }
                                }

                                if (Vita <= 0)
                                {
                                    Console.WriteLine("GAME OVER. Sei stato sconfitto da ChainChomp, il tuo viaggio finisce qui...                                     Riprovi?");
                                    Environment.Exit(0);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Valore tiro dado: " + TiroDado);
                                Console.WriteLine("Sei riuscito ad attaccare il ChainChomp, gli hai inflitto " + Attacco + " danni! Premi un tato per continuare...");
                                Console.ReadLine();
                                ChainChompVita -= Attacco;
                                StatusPersonaggio(Vita, Attacco, personaggi);
                                Console.WriteLine("La vita del ChainChomp è: " + ChainChompVita);

                                if (PozioneCura > 0 && Vita <= 4)
                                {
                                    Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                                    string sceltaPozione = Console.ReadLine();
                                    if (sceltaPozione == "si")
                                    {
                                        Vita += 5;
                                        PozioneCura--;
                                        Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                                    }
                                }

                                if (Vita <= 0)
                                {
                                    Console.WriteLine("GAME OVER. Sei stato sconfitto da ChainChomp, il tuo viaggio finisce qui...                                     Riprovi?");
                                    Environment.Exit(0);
                                }
                            }
                        }
                    }
                }
                else if (i == 2)//madamebrode
                {
                    Console.WriteLine("Dopo aver sconfitto la ChainComp, vieni fermato da MadameBrode!");
                    Console.WriteLine("MadameBrode è la madre dei broodals, gli scagnozzi di Bowser che cercano di rapire Peach.Ti accorgi che lei ha le chiavi della Odissey e le tiene strette, sconfiggila per riuscire a prendere le chiavi e poter viaggiare tra i mondi.");

                    while (MadameBroodeVita > 0)
                    {
                        int TiroDado5 = rand.Next(1, 7);

                        if (TiroDado5 <= 3)
                        {
                            while (MadameBroodeVita > 0)
                            {
                                Console.WriteLine("Valore tiro dado: " + TiroDado5);
                                Console.WriteLine("Non sei riuscito ad attaccare il MadameBroode, ora lei ti ha attaccato e ti ha inflitto " + MadameBroodeAttacco + " danni! Premi un tasto per continuare...");
                                Console.ReadLine();
                                Vita -= MadameBroodeAttacco;
                                StatusPersonaggio(Vita, Attacco, personaggi);
                                Console.WriteLine("La vita del MadameBroode è: " + MadameBroodeVita);

                                if (PozioneCura > 0 && Vita <= 4)
                                {
                                    Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                                    string sceltaPozione = Console.ReadLine();
                                    if (sceltaPozione == "si")
                                    {
                                        Vita += 5;
                                        PozioneCura--;
                                        Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                                    }
                                }


                                if (Vita <= 0)
                                {
                                    Console.WriteLine("GAME OVER. Sei stato sconfitto dal dinosauro, il tuo viaggio finisce qui...                                     Riprovi?");
                                    Environment.Exit(0);
                                }
                            }

                        }
                        else
                        {
                            while (MadameBroodeVita > 0)
                            {
                                Console.WriteLine("Valore tiro dado: " + TiroDado5);
                                Console.WriteLine("Sei riuscito ad attaccare MadameBroode, gli hai inflitto " + Attacco + " danni! Premi un tato per continuare...");
                                Console.ReadLine();
                                MadameBroodeVita -= Attacco;
                                StatusPersonaggio(Vita, Attacco, personaggi);
                                Console.WriteLine("La vita del MadameBroode è: " + MadameBroodeVita);

                                if (PozioneCura > 0 && Vita <= 4)
                                {
                                    Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                                    string sceltaPozione = Console.ReadLine();
                                    if (sceltaPozione == "si")
                                    {
                                        Vita += 5;
                                        PozioneCura--;
                                        Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                                    }
                                }

                                if (Vita <= 0)
                                {
                                    Console.WriteLine("GAME OVER. Sei stato sconfitto dal MadameBroode, il tuo viaggio finisce qui...                                     Riprovi?");
                                    Environment.Exit(0);
                                }
                            }
                        }
                    }

                    Console.WriteLine("Sei riuscito a sconfiggere MadameBroode! Come ricompensa per la tua vittoria, ottieni le chiavi della Odissey! Pronto per la partenza parti verso un nuovo mondo...");
                }
            }

            TurnoDiGioco(Vita, Attacco, personaggi, PozioneCura, cavalcatura, fioreDiFuoco, Mappa);
        }
        static void BoscoSolitario(string personaggi, int Vita, int Attacco, int PozioneCura, int cavalcature)
        {
            Console.WriteLine("Dopo un viaggio abbastanza lungo, arrivi nel Regno del Bosco Solitario, un luogo dove la natura e la tecnologia si fondono in un modo sorprendente. Per continuare il viaggio la Odissey ha bisogno di energia, trova le tre lune di energia e potenzia la Odissey.");
            Console.WriteLine(personaggi + ": Mamma mia! Che posto! Sembra... una foresta in cui ha vissuto un robot gigante!");
            Console.WriteLine(personaggi + ": Guarda Cappy, gli alberi sono fatti di legno, ma anche di tubi! E che strano silenzio... meglio tenere gli occhi aperti. Non mi fido di una foresta così perfetta.");
            Console.WriteLine(personaggi + ": Dobbiamo trovare la Luna di Energia! Sento che è nascosta da qualche parte... tra le foglie o forse... sotto una di quelle piattaforme! Andiamo!");

            string[] BoscoSolitario = { "VermeElettrico", "Piranha", "Mega pianta Piranha" };

            Random rand = new Random();
            Random Fuga = new Random();

            int VermeElettricoVita = 4, VermeElettricoAttacco = 1, PiranhaVita = 6, PiranhaAttacco = 1, TopperVita = 8, TopperAttacco = 2;

            for (int i = 0; i < BoscoSolitario.Length; i++)
            {
                if (i == 0) //VermeElettrico
                {
                    Console.WriteLine("Appena sceso dalla odissey ti devi scontrare con un Verme Elettrico che ti blocca la strada! Il Verme Elettrico è un nemico che incarna perfettamente la fusione tra natura e tecnologia tipica del Regno Bosco. Non è un essere organico né un robot puro, ma una strana combinazione di entrambi.");

                    while (VermeElettricoVita > 0)
                    {
                        int TiroDado = rand.Next(1, 7);

                        if (TiroDado <= 2)
                        {
                            Console.WriteLine("Valore tiro dado: " + TiroDado);
                            Console.WriteLine("Non sei riuscito ad attaccare il VermeElettrico, ora lui ti ha attaccato e ti ha inflitto " + VermeElettricoAttacco + " danni! Premi un tasto per continuare...");
                            Console.ReadLine();
                            Vita -= VermeElettricoAttacco;
                            StatusPersonaggio(Vita, Attacco, personaggi);
                            Console.WriteLine("La vita del VermeElettrico è: " + VermeElettricoVita);

                            if (PozioneCura > 0 && Vita <= 4)
                            {
                                Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                                string sceltaPozione = Console.ReadLine();
                                if (sceltaPozione == "si")
                                {
                                    Vita += 5;
                                    PozioneCura--;
                                    Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                                }
                            }

                            if (Vita <= 0)
                            {
                                Console.WriteLine("GAME OVER. Sei stato sconfitto dal VermeElettrico, il tuo viaggio finisce qui...                                     Riprovi?");
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Valore tiro dado: " + TiroDado);
                            Console.WriteLine("Sei riuscito ad attaccare il VermeElettrico, gli hai inflitto " + Attacco + " danni! Premi un tato per continuare...");
                            Console.ReadLine();
                            VermeElettricoVita -= Attacco;
                            StatusPersonaggio(Vita, Attacco, personaggi);
                            Console.WriteLine("La vita del VermeElettrico è: " + VermeElettricoVita);

                            if (PozioneCura > 0 && Vita <= 4)
                            {
                                Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                                string sceltaPozione = Console.ReadLine();
                                if (sceltaPozione == "si")
                                {
                                    Vita += 5;
                                    PozioneCura--;
                                    Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                                }
                            }

                            if (Vita <= 0)
                            {
                                Console.WriteLine("GAME OVER. Sei stato sconfitto dal dinosauro, il tuo viaggio finisce qui...                                     Riprovi?");
                                Environment.Exit(0);
                            }
                        }
                    }

                    Console.WriteLine("Sei riuscito a stordire il VermeElettrico! Come ricompensa per la tua vittoria, ottieni una Pozione Cura!");

                    PozioneCura++;
                }
                else if (i == 1)//Piranha
                {
                    Console.WriteLine("Proseguendo nel tuo cammino alla ricerca delle lune, vieni attaccato da una Piranha! Una pianta carnivora meccanica che difende gelosamente il territorio. Attaccala per continuare il viaggio con probabile ricompensa oppuna non rischi e provi a fuggire via?.");
                    Console.WriteLine(" Cosa scegli di fare? ");
                    Console.WriteLine(" 1: Affrontare il Dinosauro, con possibile ricompensa ");
                    Console.WriteLine(" 2: Fuggire via dalla via di fuga senza prendere rischi ");
                    string scelta = Console.ReadLine();

                    if (scelta == "1")
                    {
                        Console.WriteLine("Hai deciso di affrontare il Dinosauro!");

                        while (PiranhaVita > 0)
                        {
                            int TiroDado = rand.Next(1, 7);

                            if (TiroDado <= 2)
                            {
                                Console.WriteLine("Valore tiro dado: " + TiroDado);
                                Console.WriteLine("Non sei riuscito ad attaccare il Piranha, ora lui ti ha attaccato e ti ha inflitto " + PiranhaAttacco + " danni! Premi un tasto per continuare...");
                                Console.ReadLine();
                                Vita -= PiranhaAttacco;
                                StatusPersonaggio(Vita, Attacco, personaggi);
                                Console.WriteLine("La vita di Piranha è: " + PiranhaVita);

                                if (PozioneCura > 0 && Vita <= 4)
                                {
                                    Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                                    string sceltaPozione = Console.ReadLine();
                                    if (sceltaPozione == "si")
                                    {
                                        Vita += 5;
                                        PozioneCura--;
                                        Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                                    }
                                }

                                if (Vita <= 0)
                                {
                                    Console.WriteLine("GAME OVER. Sei stato sconfitto da Piranha, il tuo viaggio finisce qui...                                     Riprovi?");
                                    Environment.Exit(0);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Valore tiro dado: " + TiroDado);
                                Console.WriteLine("Sei riuscito ad attaccare il Piranha, gli hai inflitto " + Attacco + " danni! Premi un tato per continuare...");
                                Console.ReadLine();
                                PiranhaVita -= Attacco;
                                StatusPersonaggio(Vita, Attacco, personaggi);
                                Console.WriteLine("La vita del Piranha è: " + PiranhaVita);

                                if (PozioneCura > 0 && Vita <= 4)
                                {
                                    Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                                    string sceltaPozione = Console.ReadLine();
                                    if (sceltaPozione == "si")
                                    {
                                        Vita += 5;
                                        PozioneCura--;
                                        Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                                    }
                                }

                                if (Vita <= 0)
                                {
                                    Console.WriteLine("GAME OVER. Sei stato sconfitto da Piranha, il tuo viaggio finisce qui...                                     Riprovi?");
                                    Environment.Exit(0);
                                }
                            }
                        }

                        Console.WriteLine("Sei riuscito a stordire il Piranha! Come ricompensa per la tua vittoria, ottieni l'altra metà di cavalcatura, questa ti permette di poter viaggiare piu velocemente tra i vari mondi aumentando di 1 il valore del dado.");

                        cavalcature++;

                        Console.WriteLine("Ora che il Piranha è stordito puoi continuare il tuo viaggio alla ricerca delle lune.");
                    }
                    else if (scelta == "2")//fuga Piranha
                    {
                        Console.WriteLine("Hai deciso di fuggire via dalla via di fuga!");
                        Console.WriteLine("Puoi fuggire via solo se otterrai un valore superiore a 75 nel tiro del dado!");

                        int TiroDadoFuga = Fuga.Next(1, 101);

                        if (TiroDadoFuga > 75)
                        {
                            Console.WriteLine("Valore tiro dado fuga: " + TiroDadoFuga);
                            Console.WriteLine("Sei riuscito a fuggire via da Piranha utilizzando la via di fuga!");

                        }
                        else
                        {
                            Console.WriteLine("Valore tiro dado fuga: " + TiroDadoFuga);
                            Console.WriteLine("Non sei riuscito a fuggire via da Piranha, ti ha catturato. Prova ad attaccarlo!");

                            while (PiranhaVita > 0)
                            {
                                int TiroDado2 = rand.Next(1, 7);

                                if (TiroDado2 <= 2)
                                {
                                    Console.WriteLine("Valore tiro dado: " + TiroDado2);
                                    Console.WriteLine("Non sei riuscito ad attaccare il Piranha, ora lui ti ha attaccato e ti ha inflitto " + PiranhaAttacco + " danni! Premi un tasto per continuare...");
                                    Console.ReadLine();
                                    Vita -= PiranhaAttacco;
                                    StatusPersonaggio(Vita, Attacco, personaggi);
                                    Console.WriteLine("La vita del Piranha è: " + PiranhaVita);

                                    if (PozioneCura > 0 && Vita <= 4)
                                    {
                                        Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                                        string sceltaPozione = Console.ReadLine();
                                        if (sceltaPozione == "si")
                                        {
                                            Vita += 5;
                                            PozioneCura--;
                                            Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                                        }
                                    }

                                    if (Vita <= 0)
                                    {
                                        Console.WriteLine("GAME OVER. Sei stato sconfitto da Piranha, il tuo viaggio finisce qui...                                     Riprovi?");
                                        Environment.Exit(0);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Valore tiro dado: " + TiroDado2);
                                    Console.WriteLine("Sei riuscito ad attaccare il Piranha, gli hai inflitto " + Attacco + " danni! Premi un tasto per continuare...");
                                    Console.ReadLine();
                                    PiranhaVita -= Attacco;
                                    StatusPersonaggio(Vita, Attacco, personaggi);
                                    Console.WriteLine("La vita di Piranha è: " + PiranhaVita);

                                    if (PozioneCura > 0 && Vita <= 4)
                                    {
                                        Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                                        string sceltaPozione = Console.ReadLine();
                                        if (sceltaPozione == "si")
                                        {
                                            Vita += 5;
                                            PozioneCura--;
                                            Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                                        }
                                    }

                                    if (Vita <= 0)
                                    {
                                        Console.WriteLine("GAME OVER. Sei stato sconfitto da Piranha, il tuo viaggio finisce qui...                                     Riprovi?");
                                        Environment.Exit(0);
                                    }
                                }
                            }

                            Console.WriteLine("Sei riuscito a stordire il Piranha! Come ricompensa per la tua vittoria, ottieni l'altra metà di cavalcatura, questa ti permette di poter viaggiare piu velocemente tra i vari mondi aumentando di 1 il valore del dado.");

                            cavalcature++;

                            Console.WriteLine("Ora che il Piranha è stordito puoi continuare il tuo viaggio alla ricerca delle lune.");
                        }
                    }

                }
                else if (i == 2)//Topper
                {
                    Console.WriteLine("Dopo aver sconfitto il Piranha sali in cima all'osservatorio presente inmezzo alla mappa e incontri Topper che tiene custodite le lune di energia che propio ti servono. Topper è il leader, scontroso e arrogante, dei Broodals, i conigli wedding planner di Bowser. Si distingue per il suo cappello a cilindro verde che utilizza come arma d'attacco e di difesa. Durante il combattimento, impila i suoi numerosi cappelli creando una torre instabile. Per sconfiggerlo, Mario deve Cap-turare il suo cappello per esporlo all'attacco.Sconfiggilo in un duello e potrai ripartire per un nuovo mondo.");

                    while (TopperVita > 0)
                    {
                        int TiroDado = rand.Next(1, 7);

                        if (TiroDado <= 2)
                        {
                            Console.WriteLine("Valore tiro dado: " + TiroDado);
                            Console.WriteLine("Non sei riuscito ad attaccare Topper, ora lui ti ha attaccato e ti ha inflitto " + TopperAttacco + " danni! Premi un tasto per continuare...");
                            Console.ReadLine();
                            Vita -= TopperAttacco;
                            StatusPersonaggio(Vita, Attacco, personaggi);
                            Console.WriteLine("La vita di Topper è: " + TopperVita);

                            if (PozioneCura > 0 && Vita <= 4)
                            {
                                Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                                string sceltaPozione = Console.ReadLine();
                                if (sceltaPozione == "si")
                                {
                                    Vita += 5;
                                    PozioneCura--;
                                    Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                                }
                            }

                            if (Vita <= 0)
                            {
                                Console.WriteLine("GAME OVER. Sei stato sconfitto da Topper, il tuo viaggio finisce qui...                                     Riprovi?");
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Valore tiro dado: " + TiroDado);
                            Console.WriteLine("Sei riuscito ad attaccare il Topper, gli hai inflitto " + Attacco + " danni! Premi un tato per continuare...");
                            Console.ReadLine();
                            TopperVita -= Attacco;
                            StatusPersonaggio(Vita, Attacco, personaggi);
                            Console.WriteLine("La vita del Topper è: " + TopperVita);

                            if (PozioneCura > 0 && Vita <= 4)
                            {
                                Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                                string sceltaPozione = Console.ReadLine();
                                if (sceltaPozione == "si")
                                {
                                    Vita += 5;
                                    PozioneCura--;
                                    Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                                }
                            }

                            if (Vita <= 0)
                            {
                                Console.WriteLine("GAME OVER. Sei stato sconfitto da Topper, il tuo viaggio finisce qui...                                     Riprovi?");
                                Environment.Exit(0);
                            }
                        }
                    }

                    Console.WriteLine("Sei riuscito a sconfiggere Topper! Puoi andare tranquillamente a prenderere le lune di energia e tornare alla Odissey.");
                }
            }

        }
        static void Imprevisto(int Vita, int Attacco, string personaggi, int PozioneCura)
        {
            int TREXVita = 6, TREXAttacco = 2, PiranhaVita = 8, PiranhaAttacco = 2;
            Console.WriteLine("Durante il viaggio verso il prossimo mondo, un'improvvisa tempesta cosmica scuote la Odissey, costringendo Mario a manovrare con abilità per evitare detriti spaziali e onde di energia instabile. Mentre la nave viene scossa, Mario si aggrappa saldamente a Cappy. Durante la tempesta la Odyssey si rompe e precipiti giu ad alte velocità, ma per fortuna l'impatto viene attutito da un gruppo di alberi. Quando esci dalla odissey ti ritrovi in un isola piena di dinosauri, la odissey è tutta a pezzi e sono sparsi su tutta l'isola. Recuperali e possiamo ripartire.");
            Console.WriteLine("Devi trovare 3 pezzi della odissey per poter ripartire, buona fortuna!");
            Console.WriteLine("Mario parte alla ricerca del primo pezzo della odissey... fino a quando non si accorge che un T-REX sta custodendo uno dei tre pezzi, prova ad avvicinarti e prenderlo senza farti vedere, se ti farai vedere dovrai combattere un duello.");
            Console.WriteLine("Per riuscire a prendere il pezzo della odissey senza farti vedere dal T-REX devi totalizzare un punteggio maggiore di 75 nel tiro di un dado da 100.");

            Random rand = new Random();
            int TiroDadoStealt = rand.Next(1, 101);

            if (TiroDadoStealt > 75)
            {
                Console.WriteLine("Valore tiro dado stealt: " + TiroDadoStealt);
                Console.WriteLine("Sei riuscito a prendere il pezzo della odissey senza farti vedere dal T-REX! Ora prosegui nella ricerca degli altri pezzi.");
            }
            else
            {
                Console.WriteLine("Valore tiro dado stealt: " + TiroDadoStealt);
                Console.WriteLine("Non sei riuscito a prendere il pezzo della odissey senza farti vedere dal T-REX, ora dovrai affrontarlo in un duello per riuscire a prendere il pezzo della odissey.");

                while (TREXVita > 0)
                {
                    int TiroDado = rand.Next(1, 7);

                    if (TiroDado <= 2)
                    {
                        Console.WriteLine("Valore tiro dado: " + TiroDado);
                        Console.WriteLine("Non sei riuscito ad attaccare Topper, ora lui ti ha attaccato e ti ha inflitto " + TREXAttacco + " danni! Premi un tasto per continuare...");
                        Console.ReadLine();
                        Vita -= TREXAttacco;
                        StatusPersonaggio(Vita, Attacco, personaggi);
                        Console.WriteLine("La vita di Topper è: " + TREXVita);

                        if (PozioneCura > 0 && Vita <= 4)
                        {
                            Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                            string sceltaPozione = Console.ReadLine();
                            if (sceltaPozione == "si")
                            {
                                Vita += 5;
                                PozioneCura--;
                                Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                            }
                        }

                        if (Vita <= 0)
                        {
                            Console.WriteLine("GAME OVER. Sei stato sconfitto da Topper, il tuo viaggio finisce qui...                                     Riprovi?");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valore tiro dado: " + TiroDado);
                        Console.WriteLine("Sei riuscito ad attaccare il Topper, gli hai inflitto " + Attacco + " danni! Premi un tato per continuare...");
                        Console.ReadLine();
                        TREXVita -= Attacco;
                        StatusPersonaggio(Vita, Attacco, personaggi);
                        Console.WriteLine("La vita del Topper è: " + TREXVita);

                        if (PozioneCura > 0 && Vita <= 4)
                        {
                            Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                            string sceltaPozione = Console.ReadLine();
                            if (sceltaPozione == "si")
                            {
                                Vita += 5;
                                PozioneCura--;
                                Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                            }
                        }

                        if (Vita <= 0)
                        {
                            Console.WriteLine("GAME OVER. Sei stato sconfitto da Topper, il tuo viaggio finisce qui...                                     Riprovi?");
                            Environment.Exit(0);
                        }
                    }
                }
            }

            Console.WriteLine("Sei riuscito a sconfiggere il T-REX! Ora puoi prendere il pezzo della odissey che stava custodendo e proseguire nella ricerca degli altri pezzi.");
            Console.ReadLine();
            Console.WriteLine("Un'altro pezzo viene custodito da un gruppo di piranha meccaniche, dovrai combattere e sudare per prendere questo pezzo.");

            while (PiranhaVita > 0)
            {
                int TiroDado = rand.Next(1, 7);

                if (TiroDado <= 2)
                {
                    Console.WriteLine("Valore tiro dado: " + TiroDado);
                    Console.WriteLine("Non sei riuscito ad attaccare il Piranha, ora lui ti ha attaccato e ti ha inflitto " + PiranhaAttacco + " danni! Premi un tasto per continuare...");
                    Console.ReadLine();
                    Vita -= PiranhaAttacco;
                    StatusPersonaggio(Vita, Attacco, personaggi);
                    Console.WriteLine("La vita di Piranha è: " + PiranhaVita);

                    if (PozioneCura > 0 && Vita <= 4)
                    {
                        Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                        string sceltaPozione = Console.ReadLine();
                        if (sceltaPozione == "si")
                        {
                            Vita += 5;
                            PozioneCura--;
                            Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                        }
                    }

                    if (Vita <= 0)
                    {
                        Console.WriteLine("GAME OVER. Sei stato sconfitto da Piranha, il tuo viaggio finisce qui...                                     Riprovi?");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("Valore tiro dado: " + TiroDado);
                    Console.WriteLine("Sei riuscito ad attaccare il Piranha, gli hai inflitto " + Attacco + " danni! Premi un tato per continuare...");
                    Console.ReadLine();
                    PiranhaVita -= Attacco;
                    StatusPersonaggio(Vita, Attacco, personaggi);
                    Console.WriteLine("La vita del Piranha è: " + PiranhaVita);

                    if (PozioneCura > 0 && Vita <= 4)
                    {
                        Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                        string sceltaPozione = Console.ReadLine();
                        if (sceltaPozione == "si")
                        {
                            Vita += 5;
                            PozioneCura--;
                            Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                        }
                    }

                    if (Vita <= 0)
                    {
                        Console.WriteLine("GAME OVER. Sei stato sconfitto da Piranha, il tuo viaggio finisce qui...                                     Riprovi?");
                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine("Sei riuscito a sconfiggere il gruppo di Piranha! Ora puoi prendere il pezzo della odissey che stavano custodendo e proseguire nella ricerca dell'ultimo pezzo.");
            Console.WriteLine("Mentre stai tornando alla odissey per ripararla, noti un bagliore tra gli alberi. Avvicinandoti, scopri che l'ultimo pezzo è rimasto tra un albero, per fortuna sei un bravo arrampicatore e quindi riesci a trovare tutti e tre i pezzi e dopo aver riparato la odissey ritorni in cammino verso il prossimo regno.");
        }
        static void NewDonkCity(string personaggi, int Vita, int Attacco, int PozioneCura)
        {
            int salti = 0, HarietVita = 8, HarietAttacco = 2;
            Random rand = new Random();

            Console.WriteLine("Dopo un lungo e turbolento viaggio, arrivi nel Regno di New Donk City, una metropoli vibrante e piena di vita, ispirata alle grandi città degli anni '30. Per continuare il viaggio la Odissey ha bisogno di energia, trova le tre lune di energia e potenzia la Odissey.");
            Console.WriteLine(personaggi + "osserva con meraviglia l'architettura art déco degli edifici, le strade affollate di cittadini antropomorfi e l'atmosfera vivace che permea ogni angolo della città. Con Cappy al suo fianco, è pronto ad affrontare le sfide che lo attendono in questo regno urbano.");
            Console.WriteLine("Esplorando la citta ti imbatti con donkey Kong che ti sfida in una gara di salto sui tetti per dimostrare la tua abilità e ottenere una delle lune di energia necessarie per potenziare la Odissey. Accetti la sfida e ti prepari a saltare da un tetto all'altro, cercando di evitare ostacoli (1) oppure ti concentri a trovare le tre lune (2)?.");
            int scelta = Convert.ToInt32(Console.ReadLine());

            if (scelta == 1)
            {
                Random rand1 = new Random();

                Console.WriteLine("Hai deciso di affrontare la sfida di Donkey Kong!");
                Console.WriteLine("Per vincere la gara devi fare almeno 3 ottimi salti di fila, un ottimo salto è se sul lancio di un dado farai sopra a 65. Buona fortuna!");

                while (salti < 3)
                {
                    int TiroDadoSalto = rand1.Next(1, 101);
                    if (TiroDadoSalto > 65)
                    {
                        salti++;
                        Console.WriteLine("Valore tiro dado salto: " + TiroDadoSalto);
                        Console.WriteLine("Ottimo salto! Hai fatto " + salti + " ottimi salti di fila.");
                    }
                    else
                    {
                        salti = 0;
                        Console.WriteLine("Valore tiro dado salto: " + TiroDadoSalto);
                        Console.WriteLine("Salto non riuscito! Devi ricominciare da capo.");
                    }
                }
                Console.WriteLine("Dopo una gara intensa e piena di salti acrobatici, riesci a superare Donkey Kong e a ottenere la luna di energia! Donkey Kong, impressionato dalla tua abilità, ti consegna la luna con un sorriso amichevole e ti da anche una pozione di cura. Ora puoi continuare il tuo viaggio alla ricerca delle altre lune di energia per potenziare la Odissey.");
                Console.WriteLine("Visto che hai vinto Donkey Kong ti dà un'indizio su dove trovare le altre lune, si trovano in cima all'Empire state building.");
                PozioneCura++;
            }
            else if (scelta == 2)
            {
                Console.WriteLine("Hai deciso di concentrarti a trovare le tre lune!");
            }

            Console.WriteLine("Mentre esplori la città, noti l'Empire State Building che si erge maestoso tra gli altri grattacieli. Decidi di salire in cima per cercare le lune di energia.");
            Console.WriteLine("Appena arrivato vedi subito le tre lune di energia, ma vieni respinto da Hariet, l'unico membro femminile del quartetto, usa bombe pirotecniche e indossa un abito rosa. Sconfiggila e prenditi le lune.");

            while (HarietVita > 0)
            {
                int TiroDado = rand.Next(1, 7);

                if (TiroDado <= 2)
                {
                    Console.WriteLine("Valore tiro dado: " + TiroDado);
                    Console.WriteLine("Non sei riuscito ad attaccare il Hariet, ora lui ti ha attaccato e ti ha inflitto " + HarietAttacco + " danni! Premi un tasto per continuare...");
                    Console.ReadLine();
                    Vita -= HarietAttacco;
                    StatusPersonaggio(Vita, Attacco, personaggi);
                    Console.WriteLine("La vita di Hariet è: " + HarietVita);

                    if (PozioneCura > 0 && Vita <= 4)
                    {
                        Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                        string sceltaPozione = Console.ReadLine();
                        if (sceltaPozione == "si")
                        {
                            Vita += 5;
                            PozioneCura--;
                            Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                        }
                    }

                    if (Vita <= 0)
                    {
                        Console.WriteLine("GAME OVER. Sei stato sconfitto da Hariet, il tuo viaggio finisce qui...                                     Riprovi?");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("Valore tiro dado: " + TiroDado);
                    Console.WriteLine("Sei riuscito ad attaccare Hariet, gli hai inflitto " + Attacco + " danni! Premi un tato per continuare...");
                    Console.ReadLine();
                    HarietVita -= Attacco;
                    StatusPersonaggio(Vita, Attacco, personaggi);
                    Console.WriteLine("La vita di Hariet è: " + HarietVita);

                    if (PozioneCura > 0 && Vita <= 4)
                    {
                        Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                        string sceltaPozione = Console.ReadLine();
                        if (sceltaPozione == "si")
                        {
                            Vita += 5;
                            PozioneCura--;
                            Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                        }
                    }

                    if (Vita <= 0)
                    {
                        Console.WriteLine("GAME OVER. Sei stato sconfitto da Hariet, il tuo viaggio finisce qui...                                     Riprovi?");
                        Environment.Exit(0);
                    }
                }
            }
            Console.WriteLine("Sei riuscito a sconfiggere Hariet! Ora puoi prendere le lune di energia e tornare alla Odissey.");
        }
        static void Bruma(string personaggi, int Vita, int Attacco, int PozioneCura)
        {
            Console.WriteLine(personaggi + " scese dalla sua Odyssey in un mondo saturo di bruma grigio-verdastra, una nebbia densa che inghiottiva la luce fioca dei neon al mercurio. L'aria era gelida, densa di un odore acre di ozono e metallo bruciato. Il paesaggio era un labirinto di ruggine e cemento, con silos e tubazioni che si perdevano nel nulla. Dominava un ronzio costante e profondo, interrotto solo dal suono amplificato dei suoi passi sull'asfalto oleoso e bagnato. In lontananza, ombre umane si muovevano lente, sagome silenziose e piegate che sembravano parte stessa della desolazione industriale di Bruma.");
            Console.WriteLine("La Odissey ha bisogno di energia, recupera le tre lune di esergia e possiamo continuare il viaggio.");

            Random rand = new Random();
            Random Fuga = new Random();
            int RobotanicoTossicoVita = 6, RobotanicoTossicoAttacco = 1, SpewartVita = 8, SpewartAttacco = 2;

            Console.WriteLine("Lungo il tragitto incontri Robotanico Tossico, Un grande robot che pattuglia le aree industriali. Attacca rilasciando nebbia pressurizzata, creando campi elettrici. Sei circondato di nebbia ma riesci a trovare una via di fuga. Cosa scegli di fare, combatti (1) oppure tenti di fuggire (2)");
            string scelta = Console.ReadLine();

            if (scelta == "1")
            {
                Console.WriteLine("Hai deciso di affrontare RobotanicoTossico!");

                while (RobotanicoTossicoVita > 0)
                {
                    int TiroDado = rand.Next(1, 7);

                    if (TiroDado <= 2)
                    {
                        Console.WriteLine("Valore tiro dado: " + TiroDado);
                        Console.WriteLine("Non sei riuscito ad attaccare RobotanicoTossico, ora lui ti ha attaccato e ti ha inflitto " + RobotanicoTossicoAttacco + " danni! Premi un tasto per continuare...");
                        Console.ReadLine();
                        Vita -= RobotanicoTossicoAttacco;
                        StatusPersonaggio(Vita, Attacco, personaggi);
                        Console.WriteLine("La vita di RobotanicoTossico è: " + RobotanicoTossicoVita);

                        if (Vita <= 0)
                        {
                            Console.WriteLine("GAME OVER. Sei stato sconfitto da RobotanicoTossico, il tuo viaggio finisce qui...                                     Riprovi?");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valore tiro dado: " + TiroDado);
                        Console.WriteLine("Sei riuscito ad attaccare RobotanicoTossico, gli hai inflitto " + Attacco + " danni! Premi un tato per continuare...");
                        Console.ReadLine();
                        RobotanicoTossicoVita -= Attacco;
                        StatusPersonaggio(Vita, Attacco, personaggi);
                        Console.WriteLine("La vita di RobotanicoTossico è: " + RobotanicoTossicoVita);

                        if (Vita <= 0)
                        {
                            Console.WriteLine("GAME OVER. Sei stato sconfitto da RobotanicoTossico, il tuo viaggio finisce qui...                                     Riprovi?");
                            Environment.Exit(0);
                        }
                    }
                }

                Console.WriteLine("Sei riuscito a stordire RobotanicoTossico! Come ricompensa per la tua vittoria, ottieni una Pozione Cura!");

                PozioneCura++;

                Console.WriteLine("Ora che RobotanicoTossico è stordito puoi usare cappy per possederlo e riuscire a sgomberare la nebbia e trovare il covo di spewart");
            }
            else if (scelta == "2")//fuga RoobtanicoTossico
            {
                Console.WriteLine("Hai deciso di fuggire via dalla via di fuga!");
                Console.WriteLine("Puoi fuggire via solo se otterrai un valore superiore a 80 nel tiro del dado!");

                int TiroDadoFuga = Fuga.Next(1, 101);

                if (TiroDadoFuga > 80)
                {
                    Console.WriteLine("Valore tiro dado fuga: " + TiroDadoFuga);
                    Console.WriteLine("Sei riuscito a fuggire via da RobotanicoTossico utilizzando la via di fuga!");
                }
                else
                {
                    Console.WriteLine("Valore tiro dado fuga: " + TiroDadoFuga);
                    Console.WriteLine("Non sei riuscito a fuggire via da RobotanicoTossico, prova ad attaccarlo!");

                    while (RobotanicoTossicoVita > 0)
                    {
                        int TiroDado2 = rand.Next(1, 7);

                        if (TiroDado2 <= 2)
                        {
                            Console.WriteLine("Valore tiro dado: " + TiroDado2);
                            Console.WriteLine("Non sei riuscito ad attaccare RobotanicoTossico, ora lui ti ha attaccato e ti ha inflitto " + RobotanicoTossicoAttacco + " danni! Premi un tasto per continuare...");
                            Console.ReadLine();
                            Vita -= RobotanicoTossicoAttacco;
                            StatusPersonaggio(Vita, Attacco, personaggi);
                            Console.WriteLine("La vita di RobotanicoTossico è: " + RobotanicoTossicoVita);

                            if (Vita <= 0)
                            {
                                Console.WriteLine("GAME OVER. Sei stato sconfitto da RobotanicoTossico, il tuo viaggio finisce qui...                                     Riprovi?");
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Valore tiro dado: " + TiroDado2);
                            Console.WriteLine("Sei riuscito ad attaccare RobotanicoTossico, gli hai inflitto " + Attacco + " danni! Premi un tasto per continuare...");
                            Console.ReadLine();
                            RobotanicoTossicoVita -= Attacco;
                            StatusPersonaggio(Vita, Attacco, personaggi);
                            Console.WriteLine("La vita di RobotanicoTossico è: " + RobotanicoTossicoVita);

                            if (Vita <= 0)
                            {
                                Console.WriteLine("GAME OVER. Sei stato sconfitto da RobotanicoTossico, il tuo viaggio finisce qui...                                     Riprovi?");
                                Environment.Exit(0);
                            }
                        }
                    }

                    Console.WriteLine("Sei riuscito a stordire RobotanicoTossico! Come ricompensa per la tua vittoria, ottieni una Pozione Cura!");

                    PozioneCura++;

                    Console.WriteLine("Ora che RobotanicoTossico è stordito puoi usare cappy per possederlo e riuscire a sgomberare la nebbia e trovare il covo di spewart");
                }
            }

            Console.WriteLine("Dopo aver usato Cappy per possedere RobotanicoTossico, riesci a dissipare la nebbia tossica che avvolge Bruma. Con la visibilità finalmente ripristinata, individui il covo di Spewart, il Broodal vestito di blu che sputa veleno, nascosto tra le rovine industriali. Preparati ad affrontarlo e a recuperare le lune di energia necessarie per potenziare la Odissey e continuare il tuo viaggio.");
            Console.WriteLine("Ti avventuri nel covo di Spewart, pronto a sfidarlo. Spewart ti appare all'improvviso con un attacco, non riesci a schivarlo wuindi subisci danno.");
            Vita -= SpewartAttacco;
            StatusPersonaggio(Vita, Attacco, personaggi);

            Console.WriteLine("Il combattimento è iniziato!");

            while (SpewartVita > 0)
            {
                int TiroDado = rand.Next(1, 7);

                if (TiroDado <= 2)
                {
                    Console.WriteLine("Valore tiro dado: " + TiroDado);
                    Console.WriteLine("Non sei riuscito ad attaccare Spewart, ora lui ti ha attaccato e ti ha inflitto " + SpewartAttacco + " danni! Premi un tasto per continuare...");
                    Console.ReadLine();
                    Vita -= SpewartAttacco;
                    StatusPersonaggio(Vita, Attacco, personaggi);
                    Console.WriteLine("La vita di Spewart è: " + SpewartVita);

                    if (PozioneCura > 0 && Vita <= 4)
                    {
                        Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                        string sceltaPozione = Console.ReadLine();
                        if (sceltaPozione == "si")
                        {
                            Vita += 5;
                            PozioneCura--;
                            Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                        }
                    }

                    if (Vita <= 0)
                    {
                        Console.WriteLine("GAME OVER. Sei stato sconfitto da Spewart, il tuo viaggio finisce qui...                                     Riprovi?");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("Valore tiro dado: " + TiroDado);
                    Console.WriteLine("Sei riuscito ad attaccare Spewart, gli hai inflitto " + Attacco + " danni! Premi un tato per continuare...");
                    Console.ReadLine();
                    SpewartVita -= Attacco;
                    StatusPersonaggio(Vita, Attacco, personaggi);
                    Console.WriteLine("La vita di Spewart è: " + SpewartVita);

                    if (PozioneCura > 0 && Vita <= 4)
                    {
                        Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                        string sceltaPozione = Console.ReadLine();
                        if (sceltaPozione == "si")
                        {
                            Vita += 5;
                            PozioneCura--;
                            Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                        }
                    }

                    if (Vita <= 0)
                    {
                        Console.WriteLine("GAME OVER. Sei stato sconfitto da Spewart, il tuo viaggio finisce qui...                                     Riprovi?");
                        Environment.Exit(0);
                    }
                }
            }
            Console.WriteLine("Dopo un lungo e arduo combattimento, riesci a sconfiggere Spewart! Con la sua sconfitta, ottieni le lune di energia necessarie per potenziare la Odissey. Ora puoi continuare il tuo viaggio attraverso i regni cosmici, non manca molto alla fortezza di Bowser. pronto ad affrontare nuove sfide e avventure si riparte.");
        }
        static void Tirannia(string personaggi, int Vita, int Attacco, int PozioneCura, int fioreDiFuoco)
        {
            int GoombaVita = 6, GoombaAttacco = 1, RangoVita = 10, RangoAttacco = 2; ;
            bool g = false;
            Console.WriteLine("Il viaggio verso il prossimo regno è stato tranquillo, ma all'improvviso la Odissey viene risucchiata in un vortice oscuro che la trasporta in un mondo dominato dalla tirannia di Bowser. Qui, Bowser ha instaurato un regime oppressivo, governando con pugno di ferro e schiavizzando gli abitanti del regno. Libera gli abitanti sconfiggendo il mostro che li tieni in gabbia, inserisci il codice e saranno salvi. Ah non ti dimenticare delle tre lune di energia necessarie per concludere il nostro viaggio!");
            Console.WriteLine("A tenere in gabbia gli abitanti c'è una torre di Goomba corrazzata, per liberare gli abitanti devi inserire il codice segreto che è formato da 4 numeri. Ogni numero lo ottieni sconfiggendo i goomba corrazzati che pattugliano la torre.");

            Random rand = new Random();

            while (GoombaVita > 0)
            {
                int TiroDado = rand.Next(1, 7);
                if (TiroDado < 3)
                {
                    Console.WriteLine("Valore tiro dado: " + TiroDado);
                    Console.WriteLine("Non sei riuscito ad attaccare Goomba, ora lui ti ha attaccato e ti ha inflitto " + GoombaAttacco + " danni! Premi un tasto per continuare...");
                    Console.ReadLine();
                    Vita -= GoombaAttacco;
                    StatusPersonaggio(Vita, Attacco, personaggi);
                    Console.WriteLine("La vita di Goomba è: " + GoombaVita);

                    if (PozioneCura > 0 && Vita <= 4)
                    {
                        Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                        string sceltaPozione = Console.ReadLine();
                        if (sceltaPozione == "si")
                        {
                            Vita += 5;
                            PozioneCura--;
                            Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                        }
                    }

                    if (Vita <= 0)
                    {
                        Console.WriteLine("GAME OVER. Sei stato sconfitto dai Goomba, il tuo viaggio finisce qui...                                     Riprovi?");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("Valore tiro dado: " + TiroDado);
                    Console.WriteLine("Sei riuscito ad attaccare i Goomba, gli hai inflitto " + Attacco + " danni! Premi un tato per continuare...");
                    Console.ReadLine();
                    GoombaVita -= Attacco;
                    StatusPersonaggio(Vita, Attacco, personaggi);
                    Console.WriteLine("La vita di Goomba è: " + GoombaVita);

                    if (PozioneCura > 0 && Vita <= 4)
                    {
                        Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                        string sceltaPozione = Console.ReadLine();
                        if (sceltaPozione == "si")
                        {
                            Vita += 5;
                            PozioneCura--;
                            Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                        }
                    }

                    if (Vita <= 0)
                    {
                        Console.WriteLine("GAME OVER. Sei stato sconfitto da Spewart, il tuo viaggio finisce qui...                                     Riprovi?");
                        Environment.Exit(0);
                    }
                }
            }
            Console.WriteLine("Sei riuscito a sconfiggere Goomba! Il codice della gabbia è 4-2-9-7, inseriscilo per liberare gli abitanti e ottenere le lune di energia.");
            Console.WriteLine("Inserisci il codice:");
            string codiceInserito = Console.ReadLine();

            while (g == false)
            {
                if (codiceInserito == "4297")
                {
                    Console.WriteLine("Hai inserito il codice corretto! Gli abitanti sono stati liberati e ti hanno ricompensato con un Fiore di fuoco");
                    fioreDiFuoco++;
                    g = true;
                }
                else
                {
                    Console.WriteLine("Codice errato!");
                }
            }

            Console.WriteLine("Dopo aver liberato gli abitanti vai a combattere contro l'ultimo dei Broodals rimanentee, Rango, il Broodal vestito di giallo e il più alto.");
            Console.WriteLine("Il combattimento è iniziato!");
            Console.ReadLine();

            while (RangoVita > 0)
            {
                int TiroDado = rand.Next(1, 7);

                if (TiroDado < 3)
                {
                    Console.WriteLine("Valore tiro dado: " + TiroDado);
                    Console.WriteLine("Non sei riuscito ad attaccare Rango, ora lui ti ha attaccato e ti ha inflitto " + RangoAttacco + " danni! Premi un tasto per continuare...");
                    Console.ReadLine();
                    Vita -= RangoAttacco;
                    StatusPersonaggio(Vita, Attacco, personaggi);
                    Console.WriteLine("La vita di Rango è: " + RangoVita);

                    if (PozioneCura > 0 && Vita <= 4)
                    {
                        Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                        string sceltaPozione = Console.ReadLine();
                        if (sceltaPozione == "si")
                        {
                            Vita += 5;
                            PozioneCura--;
                            Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                        }
                    }

                    if (Vita <= 0)
                    {
                        Console.WriteLine("GAME OVER. Sei stato sconfitto da Rango, il tuo viaggio finisce qui...                                     Riprovi?");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("Valore tiro dado: " + TiroDado);
                    Console.WriteLine("Sei riuscito ad attaccare Rango, gli hai inflitto " + Attacco + " danni! Premi un tato per continuare...");
                    Console.ReadLine();
                    RangoVita -= Attacco;
                    StatusPersonaggio(Vita, Attacco, personaggi);
                    Console.WriteLine("La vita di Rango è: " + RangoVita);

                    if (PozioneCura > 0 && Vita <= 4)
                    {
                        Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                        string sceltaPozione = Console.ReadLine();
                        if (sceltaPozione == "si")
                        {
                            Vita += 5;
                            PozioneCura--;
                            Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                        }
                    }

                    if (Vita <= 0)
                    {
                        Console.WriteLine("GAME OVER. Sei stato sconfitto da Rango, il tuo viaggio finisce qui...                                     Riprovi?");
                        Environment.Exit(0);
                    }
                }
            }
            Console.WriteLine("Dopo un lungo e arduo combattimento, riesci a sconfiggere Rango! Con la sua sconfitta, ottieni le lune di energia necessarie per potenziare la Odissey. Ora puoi continuare il tuo viaggio e andare verso la fortezza di Bowser.");
        }
        static void BowserKingdom(string personaggi, int Vita, int Attacco, int PozioneCura, int fioreDiFuoco, int cavalcatura)
        {
            Random rand = new Random();
            int BowserVita = 15, BowserAttacco = 3;

            Console.WriteLine("L'Odyssey atterra." + personaggi + "si ritrova immerso in un paesaggio nebbioso dominato da imponenti strutture in stile orientale, fatte di pietra scura e solcate da ponti di legno. L'atmosfera è tesa, ma lo sguardo di Mario è catturato da ciò che si staglia contro il cielo plumbeo: il vasto e minaccioso castello feudale di Bowser.");
            Console.WriteLine("Con determinazione," + personaggi + "si avventura attraverso il regno di Bowser, affrontando trappole insidiose e nemici agguerriti. La sua missione è chiara: infiltrarsi nel castello di Bowser, sconfiggere il malvagio re dei Koopa e salvare la Principessa Peach una volta per tutte.");
            Console.WriteLine("Dopo aver superato varie trappole mario riesce  incontrare bowser");

            Console.WriteLine(personaggi + "Bowser! Finiamola qui! Lascia andare la Principessa Peach, subito!");
            Console.WriteLine();

            Console.WriteLine("Bowser: Ah, " + personaggi + " Sei *sempre* in tempo per rovinare il divertimento.");
            Console.WriteLine("Bowser: Ma ammettilo, il mio Regno è fantastico, no? Ho anche scelto l'abito nuziale perfetto!");
            Console.WriteLine();

            Console.WriteLine(personaggi + "Il tuo 'divertimento' è il solito pasticcio! E quel vestito non le si addice affatto!");
            Console.WriteLine(personaggi + "Non ci sarà nessun matrimonio, Bowser. Non succederà mai.");
            Console.WriteLine();

            Console.WriteLine("Bowser: Oh, ti sbagli di grosso, baffetto. Questa volta ho pensato a tutto.");
            Console.WriteLine("Bowser: Ho rubato il cappello giusto, ho il posto giusto... e quando ti avrò schiacciato, finalmente la Principessa capirà chi è il vero Re!");
            Console.WriteLine();

            Console.WriteLine("Bowser: Hai interrotto il mio grande giorno per l'ultima volta! Preparati a perdere, perché il mio potere non è mai stato così grande!");
            Console.WriteLine();

            Console.WriteLine(personaggi + "Non importa quanto grande pensi di essere, Bowser. Io e Cappy... noi siamo qui per riportare la pace nel Regno dei Funghi.");
            Console.WriteLine(personaggi + "La tua follia finisce *oggi*!");
            Console.WriteLine();

            Console.WriteLine("Cappy: Siamo pronti, Mario! Metti fine a questa farsa una volta per tutte!");
            Console.WriteLine();

            Console.WriteLine("Bowser: Basta chiacchiere! Vieni a prenderti la tua principessa, se ci riesci!");
            Console.WriteLine();

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("<< INIZIO BATTAGLIA >>");
            Console.WriteLine("--------------------------------------------------");

            InventarioPersonaggio(PozioneCura, cavalcatura, fioreDiFuoco);

            if (fioreDiFuoco > 0)
            {
                Console.WriteLine("Usi il fiore di fuoco per infliggere 2 danni in più a Bowser? (si/no)");
                string sceltaFiore = Console.ReadLine();
                if (sceltaFiore == "si")
                {
                    Console.WriteLine("Hai usato il fiore di fuoco! Hai inflitto 2 danni in più a Bowser!");
                    Attacco = Attacco + 2;
                }
                else
                {
                    Console.WriteLine("Non hai usato il fiore di fuoco.");
                }
            }

            while (BowserVita > 0)
            {
                int TiroDado = rand.Next(1, 7);

                if (TiroDado < 3)
                {
                    Console.WriteLine("Valore tiro dado: " + TiroDado);
                    Console.WriteLine("Non sei riuscito ad attaccare Bowser, ora lui ti ha attaccato e ti ha inflitto " + BowserAttacco + " danni! Premi un tasto per continuare...");
                    Console.ReadLine();
                    Vita -= BowserAttacco;
                    StatusPersonaggio(Vita, Attacco, personaggi);
                    Console.WriteLine("La vita di Bowser è: " + BowserVita);

                    if (PozioneCura > 0 && Vita <= 4)
                    {
                        Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                        string sceltaPozione = Console.ReadLine();
                        if (sceltaPozione == "si")
                        {
                            Vita += 5;
                            PozioneCura--;
                            Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                        }
                    }

                    if (Vita <= 0)
                    {
                        Console.WriteLine("GAME OVER. Sei stato sconfitto da Bowser, il tuo viaggio finisce qui...                                     Riprovi?");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("Valore tiro dado: " + TiroDado);
                    Console.WriteLine("Sei riuscito ad attaccare Bowser, gli hai inflitto " + Attacco + " danni! Premi un tato per continuare...");
                    Console.ReadLine();
                    BowserVita -= Attacco;
                    StatusPersonaggio(Vita, Attacco, personaggi);
                    Console.WriteLine("La vita di Bowser è: " + BowserVita);

                    if (PozioneCura > 0 && Vita <= 4)
                    {
                        Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                        string sceltaPozione = Console.ReadLine();
                        if (sceltaPozione == "si")
                        {
                            Vita += 5;
                            PozioneCura--;
                            Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                        }
                    }

                    if (Vita <= 0)
                    {
                        Console.WriteLine("GAME OVER. Sei stato sconfitto da Bowser, il tuo viaggio finisce qui...                                     Riprovi?");
                        Environment.Exit(0);
                    }
                }
            }
            Console.WriteLine("Evvai! Missione compiuta! Sapevo che ce l'avremmo fatta! Questa volta Bowser ha davvero esagerato, ma alla fine il vero amore vince sempre, non è vero, Principessa? Ora torniamo a casa, è ora di una meritatissima festa nel Regno dei Funghi!");
        }
        static void EventoCasuale(int PozioneCura, string personaggi, int Vita, int Attacco, int fioreDiFuoco, int cavalcatura)
        {
            Random rand = new Random();
            int evento = rand.Next(1, 101);

            int MostroVita = 6, MostroAttacco = 1;
            if (evento <= 30)
            {
                Console.WriteLine("Durante il viaggio," + personaggi + " incontra un gruppo di alieni amichevoli che gli offrono una pozione di cura come segno di amicizia.");
                PozioneCura++;
                Console.ReadLine();
            }
            else if (evento > 30 && evento <= 60)
            {
                Console.WriteLine(personaggi + " incontra un feroce mostro che lo vuole attaccare, non ha via di fuga quindi bisogna combattere.!");
                while (MostroVita > 0)
                {
                    int TiroDado = rand.Next(1, 7);

                    if (TiroDado <= 2)
                    {
                        Console.WriteLine("Valore tiro dado: " + TiroDado);
                        Console.WriteLine("Non sei riuscito ad attaccare il mostro, ora lui ti ha attaccato e ti ha inflitto " + MostroAttacco + " danni! Premi un tasto per continuare...");
                        Console.ReadLine();
                        Vita -= MostroAttacco;
                        StatusPersonaggio(Vita, Attacco, personaggi);
                        Console.WriteLine("La vita di mostro è: " + MostroVita);

                        if (PozioneCura > 0 && Vita <= 4)
                        {
                            Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                            string sceltaPozione = Console.ReadLine();
                            if (sceltaPozione == "si")
                            {
                                Vita += 5;
                                PozioneCura--;
                                Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                            }
                        }

                        if (Vita <= 0)
                        {
                            Console.WriteLine("GAME OVER. Sei stato sconfitto da mostro, il tuo viaggio finisce qui...                                     Riprovi?");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valore tiro dado: " + TiroDado);
                        Console.WriteLine("Sei riuscito ad attaccare il mostro, gli hai inflitto " + Attacco + " danni! Premi un tato per continuare...");
                        Console.ReadLine();
                        MostroVita -= Attacco;
                        StatusPersonaggio(Vita, Attacco, personaggi);
                        Console.WriteLine("La vita del mostro è: " + MostroVita);

                        if (PozioneCura > 0 && Vita <= 4)
                        {
                            Console.WriteLine("Vuoi usare una pozione di cura per recuperare 5 punti vita? (si/no)");
                            string sceltaPozione = Console.ReadLine();
                            if (sceltaPozione == "si")
                            {
                                Vita += 5;
                                PozioneCura--;
                                Console.WriteLine("Hai usato una pozione di cura! La tua vita ora è: " + Vita);
                            }
                        }

                        if (Vita <= 0)
                        {
                            Console.WriteLine("GAME OVER. Sei stato sconfitto dal mostro, il tuo viaggio finisce qui...                                     Riprovi?");
                            Environment.Exit(0);
                        }
                    }
                }
            }
            else if (evento > 60 && evento <= 85)
            {
                Console.WriteLine("Incontri toad che in cambio di una vita lui ti dà un pezzo di cavalcatura. Accetti? (si/no)");
                string sceltaToad = Console.ReadLine();
                if (sceltaToad == "si")
                {
                    Vita--;
                    cavalcatura++;
                    Console.WriteLine("Hai accettato lo scambio con toad! La tua vita ora è: " + Vita + " e il numero di cavalcature è: " + cavalcatura);
                }
                else
                {
                    Console.WriteLine("Hai rifiutato lo scambio con toad, continui il tuo viaggio.");
                }
            }
            else if (evento > 85)
            {
                Console.WriteLine("Mario si imbatte in un mercante spaziale che viene dalla terra di Fossiladia, egli dà come ricompensa a mario un FioreDiFuoco per averla liberata da MadameBroode.");
                fioreDiFuoco++;
            }
        }
        static void Viaggio(string[] Mappa)//descrizioni viaggio
        {

             if (Mappa[1] == "viaggio")
             {
                Console.WriteLine("Mario dall'oblò della sua Odissey vede allontanarsi una terra preistorica, dove un'enorme cascata ruggisce su piattaforme rocciose e dove i resti fossilizzati di un T-Rex gigantesco giacciono tra l'erba. La terra è primitiva, ma allo stesso tempo rigogliosa e vivace.");
             }
             else if (Mappa[2] == "viaggio")
             {
                Console.WriteLine("Dall’oblò della Odyssey, Mario osserva i regni trasformarsi in un mosaico di colori vibranti che fluttuano nel vuoto. Mentre la nave accelera, le scie dorate delle Power Moons illuminano il cielo, facendo sfumare i deserti infuocati nei ghiacciai azzurri e nelle foreste meccaniche. È un istante di quiete magica, sospeso tra il ricordo delle avventure appena vissute e il profilo di un nuovo, misterioso orizzonte che inizia a delinearsi tra le nuvole.");
             }
             else if (Mappa[3] == "Viaggio")
             {
                Console.WriteLine("Dall’oblò della Odyssey, Mario osserva le colossali travi di ferro rosso del Bosco Silenzioso emergere tra la nebbia fitta e i rami millenari. Mentre la nave scende di quota, la vegetazione selvaggia avvolge le vecchie macchine arrugginite, creando un contrasto unico tra natura e tecnologia. È un atterraggio suggestivo, accompagnato dal ronzio dei robot giardinieri che guardano insù, pronti ad accoglierlo nel cuore verde e meccanico del regno.");
             }
             else if (Mappa[5] == "viaggio")
             {
                Console.WriteLine("L'Odyssey si alza in volo. Mario osserva il Regno Bosco Solitario che si trasforma rapidamente in un intricato tappeto. Vede il forte contrasto tra il verde brillante delle fitte foreste di alberi squadrati e il grigio-acciaio delle strutture meccaniche. Le torri sottili dei Legnamici e le vene metalliche dei ponti aerei si rimpiccioliscono, fondendosi in un unico, sorprendente mosaico di natura ed ingegneria. Il lago scuro e le cime rocciose, dove riposa il Boss Robo-Pianta, scompaiono nella nebbia mentre l'Odyssey punta al prossimo orizzonte.");
             }
             else if (Mappa[6] == "viaggio")
             {
                Console.WriteLine("Dall’oblò della Odyssey, Mario osserva le imponenti travi di ferro rosso del Regno della Selva emergere tra le fronde dei pini giganti. Mentre la nave scende di quota, il riflesso delle Power Moons scintilla sui macchinari coperti di muschio, mescolando il vapore delle vecchie fabbriche con l'aria fresca e carica di ossigeno del sottobosco. È un momento di pura meraviglia, sospeso tra la maestosità della natura e il profilo del Bosco Silenzioso che si svela, misterioso e antico, sotto i suoi piedi.");
             }
             else if (Mappa[8] == "viaggio")
             {
                Console.WriteLine("Dopo una piccola ma brutta pausa la odissey torna a volare verso il prossimo mondo. Dall’oblò della Odyssey, Mario osserva le vette dei grattacieli di New Donk City emergere come giganti d'acciaio tra la nebbia e le nuvole. Mentre la nave scende, il riflesso dorato delle Power Moons danza sulle finestre illuminate e sulle insegne al neon, accendendo il grigio del cemento con una luce elettrica e vibrante. È un istante di pura eccitazione urbana, sospeso tra il silenzio del cielo e il battito frenetico della metropoli che lo attende, tra strade affollate e il ritmo del jazz che si sente già in lontananza.");
             }
             else if (Mappa[10] == "viaggio")
             {
                Console.WriteLine("Dall’oblò della Odyssey, Mario osserva le luci scintillanti di New Donk City farsi sempre più piccole mentre la metropoli scompare sotto un tappeto di nuvole. I profili d'acciaio dei grattacieli e le strade animate sfumano in un riflesso dorato, mentre l'eco del festival appena concluso lascia spazio al silenzio del cielo infinito. È un istante di dolce nostalgia, sospeso tra il calore della città appena salvata e il richiamo di un nuovo orizzonte che già brilla nel buio profondo dello spazio.");
             }
             else if (Mappa[11] == "viaggio")
             {
                Console.WriteLine("Dall’oblò della Odyssey, Mario osserva le torri di Bruma emergere come isole di ghiaccio tra le nubi soffici e bianche. Mentre la nave scende, il riflesso azzurro delle Power Moons scintilla sui cristalli di ghiaccio e sulle superfici metalliche, creando un gioco di luci che danza con il freddo vento artico. È un momento di pura meraviglia glaciale, sospeso tra la quiete del cielo e il profilo scintillante di Bruma che si svela, misterioso e incantato, sotto i suoi piedi.");
             }
             else if (Mappa[13] == "viaggio")
             {
                Console.WriteLine("Dall’oblò della Odyssey, Mario osserva le colline a forma di cappello del Regno di Bruma svanire lentamente tra banchi di nebbia argentea. Le sagome eleganti delle case a cilindro si confondono in un panorama monocromatico, mentre il luccichio delle Power Moons taglia l'atmosfera ovattata con bagliori magici. È un istante di profonda gratitudine, sospeso tra il ricordo del luogo dove tutto è iniziato insieme a Cappy e l’entusiasmo per il viaggio che lo porterà finalmente lontano da quel mondo di spettri e di vento.");
             }
             else if (Mappa[15] == "viaggio")
             {
                Console.WriteLine("Dall’oblò della Odyssey, Mario osserva le rovine spettrali di Tirannia svanire tra i lampi violacei e i pesanti banchi di nubi oscure. La sagoma della torre distrutta e il ricordo del drago leggendario si rimpiccioliscono, mentre il bagliore delle Power Moons squarcia l'atmosfera elettrica di quel regno dimenticato. È un istante di sollievo e mistero, sospeso tra l'oscurità di quelle terre tormentate e la luce di un nuovo orizzonte che già promette pace e colori ritrovati.");
             }
             else if (Mappa[16] == "viaggio")
             {
                Console.WriteLine("Dall’oblò della Odyssey, Mario osserva l'infinito trasformarsi in un flusso ipnotico di colori e polvere di stelle. Mentre la nave corre veloce, le scie dorate delle Power Moons illuminano il vuoto, fondendo i ricordi dei regni visitati in un unico, vibrante caleidoscopio di luce che danza sul vetro. È un istante di pace sospesa, in cui il silenzio del viaggio lo separa dalle fatiche passate e lo prepara allo stupore di un nuovo, incredibile orizzonte che sta già iniziando a brillare tra le nuvole cosmiche.");
             }
             else if (Mappa[17] == "viaggio")
             {
                Console.WriteLine("Dall’oblò della Odyssey, Mario osserva le costellazioni sfrecciare via come linee di luce, mentre la nave punta dritta verso il bagliore minaccioso del covo di Bowser. Il riflesso dorato delle ultime Power Moons raccolte illumina il suo sguardo serio e determinato, che già scruta l'orizzonte in cerca della sagoma del galeone nemico. È un istante di solenne concentrazione, sospeso tra la quiete del vuoto siderale e l'adrenalina per la battaglia finale che deciderà, una volta per tutte, il destino della Principessa Peach.");
             }
            
        }
        static void Main(string[] args)
        {
            string[] Mappa = { "Fossilandia", "viaggio", "viaggio", "viaggio", "Bosco solitario", "EventoCasuale", "viaggio", "Imprevisto", "Viaggio", "New Dowk city", "EventoCasuale", "Viaggio", "Bruma", "viaggio", "Tirannia", "viaggio", "viaggio", "viaggio", "EventoCasuale", "Bowser's Kingdom", "Viaggio con Peach" };
            int Vita = 0, Attacco = 0, cavalcatura = 0, fioreDiFuoco = 1, PozioneCura = 2;

            string p = Personaggi(ref Vita, ref Attacco);

            for (int i = 0; i < Mappa.Length; i++)
            {
                int Scelta = TurnoDiGioco(Vita, Attacco, p, PozioneCura, cavalcatura, fioreDiFuoco, Mappa);
                if(Scelta == 1)
                {
                    i++;
                    Viaggio(Mappa);
                }
                else if (Scelta == 2)
                {
                    Console.WriteLine("Hai scelto di mostrare lo status di Mario");
                    StatusPersonaggio(Vita, Attacco, p);
                }
                else if (Scelta == 3)
                {
                    Console.WriteLine("Hai scelto di mostrare l'inventario di Mario");
                    InventarioPersonaggio(PozioneCura, cavalcatura, fioreDiFuoco);
                }
                else if (Scelta == 4)
                {
                    Console.WriteLine("Hai scelto di usare un oggetto");
                    UsaOggetto(PozioneCura, Vita, Attacco, fioreDiFuoco, cavalcatura);
                }
                else if (Scelta == 5)
                {
                    Console.WriteLine("Hai scelto di uscire dal gioco");
                    Environment.Exit(0);
                }

            }
        }
    }
}