package com.cronom.mobile.androidtestmvvm.model;

import java.util.Date;

import gueei.binding.collections.ArrayListObservable;

public class ConcertViewModel {
	public ArrayListObservable<Concert>	ConcertList;

	public ConcertViewModel() {
		initializeList();
	}

	@SuppressWarnings("deprecation")
	private void initializeList() {
		this.ConcertList 	= new ArrayListObservable<Concert>(Concert.class);
		this.ConcertList.add(new Concert("Kucukciftlik Park", new Date(2013, 4, 13), "Venom", 1));
		this.ConcertList.add(new Concert("Kucukciftlik Park", new Date(2013, 4, 16), "Motorhead", 1));
		this.ConcertList.add(new Concert("Kucukciftlik Park", new Date(2013, 5, 19), "Testament", 1));
		this.ConcertList.add(new Concert("Kucukciftlik Park", new Date(2013, 5, 30), "Hellhammer", 1));
		this.ConcertList.add(new Concert("Kucukciftlik Park", new Date(2013, 6, 12), "Exodus", 1));
		this.ConcertList.add(new Concert("Kucukciftlik Park", new Date(2013, 6, 18), "Kreator", 1));
		this.ConcertList.add(new Concert("Kucukciftlik Park", new Date(2013, 7, 6), "Annihilator", 1));
		this.ConcertList.add(new Concert("Kucukciftlik Park", new Date(2013, 7, 11), "Slayer", 1));
		this.ConcertList.add(new Concert("Kucukciftlik Park", new Date(2013, 8, 21), "Overkill", 1));
	}
}
