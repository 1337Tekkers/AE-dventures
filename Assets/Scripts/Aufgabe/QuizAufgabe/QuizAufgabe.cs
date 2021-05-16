using System.Collections.Generic;

public class QuizAufgabe : IAufgabe<string[], string>
{
    private Frage frage = new Frage();
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

    // Parameter
    private readonly Dictionary<string, bool> antworten = new Dictionary<string, bool>();
    private ESchwierigkeitsgrad schwierigkeitsgrad = ESchwierigkeitsgrad.EINFACH;
    private string[] tags;

    // Spiel
    private int korrektheitsGrad = 0;
    private string selectedAntwort;


    public string[] GetAntwortOptionen()
    {
        // Würde ich gerne entfernen
        string[] answers = new string[antworten.Count];
        antworten.Keys.CopyTo(answers, 0);
        return answers;
    }

    public string GetFrage()
    {
        // Würde ich gerne entfernen
        return frage.GetValue();
    }

    public int GetKorrektheitsGrad()
    {
        return korrektheitsGrad;
    }

    public ESchwierigkeitsgrad GetSchwierigkeitsgrad()
    {
        // Würde ich gerne entfernen
        return this.schwierigkeitsgrad;
    }

    public string[] GetTags()
    {
        // Würde ich gerne entfernen
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
        this.antworten.Add(antwort, richtigAsBool);
    }

    public void SetFrage(string frage)
    {
        if (StringValidator.Validate(frage)) this.frage.WurdeGeaendert(frage);
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
        if (this.antworten[antwort])
        {
            this.korrektheitsGrad = 100;
        }
        else
        {
            korrektheitsGrad = 0;
        }
        return this.GetKorrektheitsGrad();
    }

    public void RemoveAntwort(string antwort)
    {
        if (!StringValidator.Validate(antwort)) return;
        antworten.Remove(antwort);
    }

    public void SubscribeZuFrage(IObserver<string> subscriber)
    {
        frage.Subscribe(subscriber);
    }
}
