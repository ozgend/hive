package com.cronom.mobile.androidtestmvvm.model;

import gueei.binding.observables.StringObservable;

import java.lang.reflect.Type;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

import com.google.gson.GsonBuilder;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonSerializationContext;
import com.google.gson.JsonSerializer;

public class Concert {

	public StringObservable	Hall;
	public StringObservable	DateString;
	public StringObservable	Band;
	public int				Id;

	public Concert() {
	}

	public Concert(String hall, Date date, String band, int id) {
		this.Hall = new StringObservable(hall);
		this.DateString = new StringObservable(new SimpleDateFormat("MMMM d, yyyy", Locale.US).format(date).toString());
		this.Band = new StringObservable(band);
		this.Id = id;
	}

	@Override
	public String toString() {
		return new GsonBuilder().registerTypeAdapter(Concert.class, new JsonAdapter()).create().toJson(this);
	}
	
	
	private class JsonAdapter implements JsonSerializer<Concert> {
	    @Override
	    public JsonElement serialize(Concert c, Type type, JsonSerializationContext jsc) {
	        JsonObject jsonObject = new JsonObject();
	        jsonObject.addProperty("Hall", c.Hall.get());
	        jsonObject.addProperty("DateString", c.DateString.get());
	        jsonObject.addProperty("Band", c.Band.get());
	        jsonObject.addProperty("Id", c.Id);
	        return jsonObject;      
	    }

	}
	
}
