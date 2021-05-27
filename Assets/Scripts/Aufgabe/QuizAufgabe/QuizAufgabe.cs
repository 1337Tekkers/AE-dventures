using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class QuizAufgabe
{
    [JsonProperty]
    public readonly Frage frage = new Frage();
    public class Frage : MemoryObservable<string>
    {
        public void Set(string neueFrage)
        {
            if (StringValidator.Validate(neueFrage)) {
                this.NotifyAll(neueFrage);
            }
        }
    }

    [JsonProperty]
    public readonly Antworten antworten = new Antworten();
    public class Antworten : MemoryObservable<Dictionary<int, Antwort>>
    {
        private readonly Dictionary<int, Antwort> myAntworten = new Dictionary<int, Antwort>();

        public void SetAntwort(int id, Antwort antwort)
        {
            myAntworten[id] = antwort;
            NotifyAll(myAntworten);
        }

        public void AddAntwort(Antwort antwort)
        {
            myAntworten[Count()] = antwort;
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

    public class Antwort
    {
        [JsonProperty]
        private readonly bool correct;
        [JsonProperty]
        private readonly String answer;

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

    [JsonProperty]
    public readonly Schwierigkeitsgrad schwierigkeitsgrad = new Schwierigkeitsgrad();
    public class Schwierigkeitsgrad : MemoryObservable<ESchwierigkeitsgrad>
    {
        public void Set(ESchwierigkeitsgrad schwierigkeitsgrad)
        {
            NotifyAll(schwierigkeitsgrad);
        }
    }

    [JsonProperty]
    public readonly Tag tag = new Tag();
    public class Tag : MemoryObservable<string>
    {
        public void Set(string tag)
        {
            NotifyAll(tag);
        }
    }

    public int Validiere(string antwort)
    {
        throw new NotImplementedException();
    }
}
