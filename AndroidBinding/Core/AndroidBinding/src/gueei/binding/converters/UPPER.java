package gueei.binding.converters;

import gueei.binding.Converter;
import gueei.binding.IObservable;

import java.util.Locale;

public class UPPER extends Converter<Object> {
	public static Locale	locale	= null;

	public UPPER(IObservable<?>[] dependents) {
		super(Object.class, dependents);
	}

	@Override
	public Object calculateValue(Object... args) throws Exception {
		if (args.length < 1 || args[0] == null)
			return null;
		if (locale != null)
			return String.valueOf(args[0]).toUpperCase(locale);
		return String.valueOf(args[0]).toUpperCase();
	}
}
