# NFA2DFA
[NFA][1] to [DFA][2] to convert a nondeterministic finite state automaton (**[NFA][1]**) to a deterministic finite state automaton (**[DFA][2]**).

<br/>

In the [theory of computation][3] and [automata theory][4], the **powerset construction** or **subset construction** is a standard method for [converting][5] a [nondeterministic finite automaton][1] (NFA) into a [deterministic finite automaton][2] (DFA) which recognizes the same [formal language][6]. It is important in theory because it establishes that NFAs, despite their additional flexibility, are unable to recognize any language that cannot be recognized by some DFA. It is also important in practice for converting easier-to-construct NFAs into more efficiently executable DFAs. However, if the NFA has n states, the resulting DFA may have up to 2n states, an exponentially larger number, which sometimes makes the construction impractical for large NFAs.

The construction, sometimes called the Rabin–Scott powerset construction (or subset construction) to distinguish it from similar constructions for other types of automata, was first published by [Michael O. Rabin][7] and [Dana Scott][8] in 1959.[`[1]`][9]

-------------------------
## Intuition

To simulate the operation of a DFA on a given input string, one needs to keep track of a single state at any time: the state that the automaton will reach after seeing a [prefix][10] of the input. In contrast, to simulate an NFA, one needs to keep track of a set of states: all of the states that the automaton could reach after seeing the same prefix of the input, according to the nondeterministic choices made by the automaton. If, after a certain prefix of the input, a set S of states can be reached, then after the next input symbol x the set of reachable states is a deterministic function of S and x. Therefore, the sets of reachable NFA states play the same role in the NFA simulation as single DFA states play in the DFA simulation, and in fact the sets of NFA states appearing in this simulation may be re-interpreted as being states of a DFA.[`[2]`][11]


-------------------------
## Construction

The powerset construction applies most directly to an NFA that does not allow state transformations without consuming input symbols (aka: "ε-moves"). Such an automaton may be defined as a [5-tuple][12] `(Q, Σ, T, q0, F)`, in which Q is the set of states, Σ is the set of input symbols, T is the transition function (mapping a state and an input symbol to a set of states), q0 is the initial state, and F is the set of accepting states. The corresponding DFA has states corresponding to subsets of Q. The initial state of the DFA is `{q0}`, the (one-element) set of initial states. The transition function of the DFA maps a state S (representing a subset of Q) and an input symbol x to the set `T(S,x) = ∪{T(q,x) | q ∈ S}`, the set of all states that can be reached by an x-transition from a state in S. A state S of the DFA is an accepting state if and only if at least one member of S is an accepting state of the NFA.[`[2]`][11][`[3]`][13]

In the simplest version of the powerset construction, the set of all states of the DFA is the [powerset][14] of Q, the set of all possible subsets of Q. However, many states of the resulting DFA may be useless as they may be unreachable from the initial state. An alternative version of the construction creates only the states that are actually reachable.[`[4]`][15]

### NFA with ε-moves

For an NFA with ε-moves (also called an ε-NFA), the construction must be modified to deal with these by computing the ε-[closure][16] of states: the set of all states reachable from some given state using only ε-moves. Van Noord recognizes three possible ways of incorporating this closure computation in the powerset construction:[`[5]`][17]

1. Compute the ε-closure of the entire automaton as a preprocessing step, producing an equivalent NFA without ε-moves, then apply the regular powerset construction. This version, also discussed by Hopcroft and Ullman,[`[6]`][18] is straightforward to implement, but impractical for automata with large numbers of ε-moves, as commonly arise in natural language processing application.[`[5]`][17]

2. During the powerset computation, compute the ε-closure `{q' | q --> ^{*}_\varepsilon q' \}` of each state q that is considered by the algorithm (and cache the result).

3. During the powerset computation, compute the ε-closure \{q' ~|~ \exists q \in Q', q \to^{*}_\varepsilon q' \} of each subset of states Q' that is considered by the algorithm, and add its elements to Q'.




-------------------------
[1]: https://en.wikipedia.org/wiki/Nondeterministic_finite_automaton	
[2]: https://en.wikipedia.org/wiki/Deterministic_finite_automaton
[3]: https://en.wikipedia.org/wiki/Theory_of_computation
[4]: https://en.wikipedia.org/wiki/Automata_theory
[5]: https://en.wikipedia.org/wiki/Automata_construction
[6]: https://en.wikipedia.org/wiki/Formal_language
[7]: https://en.wikipedia.org/wiki/Michael_O._Rabin
[8]: https://en.wikipedia.org/wiki/Dana_Scott
[9]: https://en.wikipedia.org/w/index.php?title=Powerset_construction&redirect=no#cite_note-1
[10]: https://en.wikipedia.org/wiki/Substring#Prefix
[11]: https://en.wikipedia.org/w/index.php?title=Powerset_construction&redirect=no#cite_note-sipser-2
[12]: https://en.wikipedia.org/wiki/Tuple
[13]: https://en.wikipedia.org/w/index.php?title=Powerset_construction&redirect=no#cite_note-hu-3
[14]: https://en.wikipedia.org/wiki/Power_set
[15]: https://en.wikipedia.org/w/index.php?title=Powerset_construction&redirect=no#cite_note-schneider-4
[16]: https://en.wikipedia.org/wiki/Reflexive_transitive_closure
[17]: https://en.wikipedia.org/w/index.php?title=Powerset_construction&redirect=no#cite_note-vannoord-5 
[18]: https://en.wikipedia.org/w/index.php?title=Powerset_construction&redirect=no#cite_note-6
[19]:
[20]: