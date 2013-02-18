package com.cronom.mobile.androidtestmvvm.model;

import gueei.binding.observables.DoubleObservable;
import gueei.binding.observables.IntegerObservable;
import gueei.binding.observables.StringObservable;

import java.lang.reflect.Type;

import android.util.Log;

import com.google.gson.GsonBuilder;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonSerializationContext;
import com.google.gson.JsonSerializer;

public class InputData {

	public  IntegerObservable	ValueInt1	= new IntegerObservable();
	public  StringObservable	ValueStr1	= new StringObservable();
	public  DoubleObservable	ValueDbl1	= new DoubleObservable();
	public  IntegerObservable	ValueInt2	= new IntegerObservable();
	public  StringObservable	ValueStr2	= new StringObservable();
	public  DoubleObservable	ValueDbl2	= new DoubleObservable();
	public  DoubleObservable	SumDbl		= new DoubleObservable();
	public  IntegerObservable	SumInt		= new IntegerObservable();

	public InputData() {
//		this.ValueInt1.set(1);
//		this.ValueStr1.set("text value 1");
//		this.ValueDbl1.set(1.3);
//		this.ValueInt2.set(2);
//		this.ValueStr2.set("text value 2");
//		this.ValueDbl2.set(2.3);
	}

	public int getSumInt() {
		this.SumInt.set(this.ValueInt1.get() + this.ValueInt2.get());
		Log.i("InputData", "getSumInt called "+ this.SumInt.get());
		return this.SumInt.get();
	}

	public double getSumDbl() {
		this.SumDbl.set(this.ValueDbl1.get() + this.ValueDbl2.get());
		Log.i("InputData", "getSumDbl called "+ this.SumDbl.get());
		return this.SumDbl.get();
	}

//	public void setSumInt(int i) {
//		Log.i("InputData", "setSumInt called");
//		this.SumInt.set(this.ValueInt1.get() + this.ValueInt2.get());
//	}
//
//	public void setSumDbl(double d) {
//		Log.i("InputData", "setSumDbl called");
//		this.SumDbl.set(this.ValueDbl1.get() + this.ValueDbl2.get());
//	}

	private class JsonAdapter implements JsonSerializer<InputData> {
		@Override
		public JsonElement serialize(InputData i, Type type, JsonSerializationContext jsc) {
			JsonObject jsonObject = new JsonObject();
			jsonObject.addProperty("ValueInt1", i.ValueInt1.get());
			jsonObject.addProperty("ValueStr1", i.ValueStr1.get());
			jsonObject.addProperty("ValueDbl1", i.ValueDbl1.get());
			jsonObject.addProperty("ValueInt2", i.ValueInt2.get());
			jsonObject.addProperty("ValueStr2", i.ValueStr2.get());
			jsonObject.addProperty("ValueDbl2", i.ValueDbl2.get());
			jsonObject.addProperty("SumDbl", i.getSumDbl());
			jsonObject.addProperty("SumInt", i.getSumInt());
			return jsonObject;
		}
	}

	@Override
	public String toString() {
		return new GsonBuilder().registerTypeAdapter(InputData.class, new JsonAdapter()).create().toJson(this);
	}
}
