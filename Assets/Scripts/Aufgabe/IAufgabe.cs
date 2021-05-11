public interface IAufgabe<O, A> {
    ESchwierigkeitsgrad GetSchwierigkeitsgrad();

    int Validiere(A antwort);

    O GetAntwortOptionen();

    string GetFrage();

    void SetFrage(string frage);

    void SetAntwort(A antwort, int richtig);

    void RemoveAntwort(A antwort);

    int GetKorrektheitsGrad();

    string[] GetTags();

    void SetTags(string[] tags);

    void SetSchwierigkeitsgrad(ESchwierigkeitsgrad schwierigkeitsgrad);
}
