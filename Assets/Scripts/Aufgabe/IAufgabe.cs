public interface IAufgabe<O, A> {
    ESchwierigkeitsgrad GetSchwierigkeitsgrad();

    int Validiere(A antwort);

    O GetAntwortOptionen();

    string GetFrage();

    string[] GetTags();

    void SetAntwort(A antwort, int richtig);

    void SetFrage(string frage);

    int GetKorrektheitsGrad();

    void SetTags(string[] tags);

    void SetSchwierigkeitsgrad(ESchwierigkeitsgrad schwierigkeitsgrad);
}
