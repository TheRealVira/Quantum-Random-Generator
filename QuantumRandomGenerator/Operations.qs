namespace Quantum.QuantumRandomGenerator
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;

    operation Set (desired: Result, q1: Qubit) : Unit
    {
        let current = M(q1);
        if (desired != current)
        {
            X(q1);
        }
    }

    operation NextBoolean (initial: Result) : (Bool)
    {
		mutable toRet = false;

        using (qubit = Qubit())
        {
            Set (initial, qubit);
			// half-flip (quantum logic)
			H(qubit);
            let res = M (qubit);

			if(res==One){
				set toRet = true;
			}

            Set(Zero, qubit);
        }

        return toRet;
    }

	operation Next(initial: Result, min: Int, max: Int): (Int){
		mutable toRet = min;

		using(qubit = Qubit()){
			for(i in 1..(max-min)){
				Set (initial, qubit);
				if(NextBoolean(initial)){
					set toRet = toRet + 1;
				}

				Set(Zero, qubit);
			}
		}

		return toRet;
	}
}
