using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class QuizAufgabe : IAufgabe<string[], string>
{
    [JsonProperty]
    private readonly Frage frage = new Frage();
    public class Frage : MemoryObservable<string>
    {
        public void WurdeGeaendert(string neueFrage)
        {
            this.NotifyAll(neueFrage);
        }

        public string GetValue()
        {
            return this.lastValue;
        }
    }

    public void SetFrage(string frage)
    {
        if (StringValidator.Validate(frage)) this.frage.WurdeGeaendert(frage);
    }

    public void SubscribeZuFrage(IObserver<string> subscriber)
    {
        frage.Subscribe(subscriber);
    }

    [JsonProperty]
    private readonly Antworten antworten = new Antworten();

    public class Antworten : MemoryObservable<Dictionary<int, Antwort>>
    {

        private readonly Dictionary<int, Antwort> myAntworten = new Dictionary<int, Antwort>();

        public void SetAntwort(int id, Antwort antwort)
        {
            myAntworten[id] = antwort;
            NotifyAll(myAntworten);
        }

        public void RemoveAntwort(int id)
        {
            myAntworten.Remove(id);
            NotifyAll(myAntworten);
        }

        public int Count()
        {
            return myAntworten.Count;
        }
    }

    public void SubscribeZuAntworten(IObserver<Dictionary<int, Antwort>> subscriber)
    {
        antworten.Subscribe(subscriber);
    }

    public class Antwort
    {
        [JsonProperty]
        readonly bool correct;
        [JsonProperty]
        readonly String answer;

        public Antwort(bool correct, String answer)
        {
            this.correct = correct;
            this.answer = answer;
        }

        public bool IsCorrect()
        {
            return correct;
        }

        override public String ToString()
        {
            return answer;
        }
    }

    public void AddAntwort(Antwort antwort)
    {
        this.antworten.SetAntwort(antworten.Count(), antwort);
    }

    public void SetAntwort(int id, Antwort antwort)
    {
        this.antworten.SetAntwort(id, antwort);
    }

    // Parameter
    // private readonly Dictionary<string, bool> antworten = new Dictionary<string, bool>();
    [JsonProperty]
    private ESchwierigkeitsgrad schwierigkeitsgrad = ESchwierigkeitsgrad.EINFACH;

    [JsonProperty]
    private string[] tags;

    // Spiel
    private int korrektheitsGrad = 0;
    private string selectedAntwort;


    public string[] GetAntwortOptionen()
    {
        // W�rde ich gerne entfernen
        // string[] answers = new string[antworten.Count];
        // antworten.Keys.CopyTo(answers, 0);
        // return answers;
        return null;
    }

    public string GetFrage()
    {
        // W�rde ich gerne entfernen
        return frage.GetValue();
    }

    public int GetKorrektheitsGrad()
    {
        return korrektheitsGrad;
    }

    public ESchwierigkeitsgrad GetSchwierigkeitsgrad()
    {
        // W�rde ich gerne entfernen
        return this.schwierigkeitsgrad;
    }

    public string[] GetTags()
    {
        // W�rde ich gerne entfernen
        return tags;
    }

    public void AddAntwort(string antwort, int richtig)
    {
        bool richtigAsBool;
        if (richtig <= 0)
        {
            richtigAsBool = false;
        }
        else
        {
            richtigAsBool = true;
        }
        // this.antworten.Add(antwort, richtigAsBool);
    }

    public void SetSchwierigkeitsgrad(ESchwierigkeitsgrad schwierigkeitsgrad)
    {
        this.schwierigkeitsgrad = schwierigkeitsgrad;
    }

    public void SetTags(string[] tags)
    {
        bool areValid = TagValidator.Validate(tags);
        if (areValid) this.tags = tags;
    }

    public int Validiere(string antwort)
    {
        this.selectedAntwort = antwort;
        // if (this.antworten[antwort])
        //{
        //    this.korrektheitsGrad = 100;
        //}
        //else
        //{
        //    korrektheitsGrad = 0;
        //}
        // return this.GetKorrektheitsGrad();
        return -1;
    }

    public void RemoveAntwort(string antwort)
    {
        // if (!StringValidator.Validate(antwort)) return;
        // antworten.Remove(antwort);
    }
}
