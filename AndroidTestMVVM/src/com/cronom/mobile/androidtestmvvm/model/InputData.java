package com.cronom.mobile.androidtestmvvm.model;

import gueei.binding.observables.DoubleObservable;
import gueei.binding.observables.IntegerObservable;
import gueei.binding.observables.StringObservable;

import java.lang.reflect.Type;

import com.google.gson.GsonBuilder;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonSerializationContext;
import com.google.gson.JsonSerializer;

public class InputData {

	public IntegerObservable ValueInt1 = new IntegerObservable(1);
	public StringObservable ValueStr1 = new StringObservable("text 1");
	public DoubleObservable ValueDbl1 = new DoubleObservable(1.1);
	public IntegerObservable ValueInt2 = new IntegerObservable(2);
	public StringObservable ValueStr2 = new StringObservable("text 2");
	public DoubleObservable ValueDbl2 = new DoubleObservable(2.2);
	public DoubleObservable SumDbl = new DoubleObservable();
	public IntegerObservable SumInt = new IntegerObservable();

	private class JsonAdapter implements JsonSerializer<InputData> {
		@Override
		public JsonElement serialize(InputData i, Type type,
				JsonSerializationContext jsc) {
			JsonObject jsonObject = new JsonObject();
			jsonObject.addProperty("ValueInt1", i.ValueInt1.get());
			jsonObject.addProperty("ValueStr1", i.ValueStr1.get());
			jsonObject.addProperty("ValueDbl1", i.ValueDbl1.get());
			jsonObject.addProperty("ValueInt2", i.ValueInt2.get());
			jsonObject.addProperty("ValueStr2", i.ValueStr2.get());
			jsonObject.addProperty("ValueDbl2", i.ValueDbl2.get());
			// jsonObject.addProperty("SumDbl", i.getSumDbl());
			// jsonObject.addProperty("SumInt", i.getSumInt());
			return jsonObject;
		}
	}

	@Override
	public String toString() {
		return new GsonBuilder()
				.registerTypeAdapter(InputData.class, new JsonAdapter())
				.create().toJson(this);
	}
}
