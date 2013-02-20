/// <reference path="jquery.fullcalendar.js" />
/// <reference path="jquery-apprise.js" />
/// <reference path="jquery-metroui.js" />
/// <reference path="jquery.js" />


var XViewer = {

    Main: {
        Panel: { Contacts: 1, Calendar: 2 },
        init: function () {
            $('#main').height(document.documentElement.clientHeight);
            $('#main-tabs').tabs({
                show: function (event, ui) {
                    switch (ui.index) {
                        case XViewer.Main.Panel.Calendar:
                            XViewer.Calendar.getList();
                            break;
                        case XViewer.Main.Panel.Contacts:
                            XViewer.Contact.getList();
                            break;
                    }
                }
            });

            XViewer.Calendar.init();
            XViewer.Contact.init();

            $('.appriseOverlay').live('click', function () {
                $('.appriseOverlay').remove();
                $('.appriseOuter').remove();
            });
        }
    },

    Calendar: {
        tmpl_event: '<li data-eid="[ID]" data-past="[PAST]" data-reqres="[REQRES]"><div><span class="listinfo-title">[TITLE]</span><br><span class="listinfo-small">[LOC]<br>[DATE]<br>[DUR]<span></div></li>',
        eventList: [],
        calendarEventList: [],
        cEvent: { id: '', title: '', allDay: '', start: '', end: '', url: '', className: '', editable: '', color: '', backgroundColor: '', borderColor: '', textColor: '' },

        init: function () {
            $('#btn-event-new').button();// .button({ icons: { primary: "ui-icon-plus" }, text: true });
            $('#btn-event-all').button();// .button({ icons: { primary: "ui-icon-calculator" }, text: true });
            $('#btn-event-delete').button();// .button({ icons: { primary: "ui-icon-close" }, text: true });
            $('#btn-event-refresh').button();// .button({ icons: { primary: "ui-icon-arrowrefresh-1-e" }, text: true });
            $('#btn-event-togglepast').button();

            $('#btn-event-new').click(function () {
                $('#calendar-wrapper').hide();
                $('#eventform-wrapper').fadeIn('fast');
                $('#calendar-event-list').fadeTo(200, 0.3);

                $('#btn-event-refresh').hide();
                $('#btn-event-delete').hide();
                $('#btn-event-new').hide();
                $('#btn-event-all').show();
            });
            $('#btn-event-all').click(function () {
                $('#eventform-wrapper').hide();
                $('#calendar-wrapper').fadeIn('fast');
                $('#calendar-event-list').fadeTo(200, 1.0);

                $('#btn-event-all').hide();
                $('#btn-event-refresh').show();
                $('#btn-event-delete').show();
                $('#btn-event-new').show();
            });
            $('#btn-event-togglepast').click(function (evt) {
                $('#calendar-event-list li[data-past="true"]').slideToggle();
                $('.oldevent').fadeToggle();
            });

            //this.getList();
        },
        getList: function () {
            XViewer.ajaxCall("XchangeViewer/Home", "GetEventList", {},
                function (resp) {
                    if (resp && resp.ok === true) {
                        XViewer.Calendar.displayList(resp.EventList);
                    }
                    else {
                        XViewer.error(resp.message);
                    }
                }
            );
        },
        displayList: function (list) {
            this.eventList = list;
            var len = list.length;
            this.toCalendarEventList(list);

            $('#calendar-event-list').html('');
            var html = "";
            for (var i = 0; i < len; i++) {
                var e = list[i];
                html += this.tmpl_event.replace("[LOC]", e.Location).replace("[TITLE]", e.Title).replace("[DATE]", e.StartStringFull).replace("[ID]", e.Id).replace("[DUR]", XViewer.calculateDuration(e.Duration)).replace("[PAST]", e.IsPast).replace("[REQRES]", e.ResponseRequired);
            }
            $('#calendar-event-list').html(html);

            $('#calendar-event-list li').on('click', function () {
                $("#calendar-event-list li div").removeClass('selected');
                $(this).children("div").addClass('selected');
                var id = $(this).data('eid');
                var item = XViewer.Calendar.getEvent(id);
                if (item.ResponseRequired) {
                    XViewer.displayEventRequest(item, function (r) {
                        if (r && r === true) {
                            XViewer.MeetingRequest.accept(id);
                        }
                    });
                }
                else {
                    XViewer.displayEvent(item);
                }
            });

            this.renderEvents();
        },
        toCalendarEventList: function (list) {
            this.calendarEventList = [];
            for (var i in list) {
                if (list[i].ResponseRequired === true) {
                    continue;
                }
                var e = {};
                e.allDay = false;
                e.editable = false;
                e.start = list[i].StartStringISO;
                e.end = list[i].EndStringISO;
                e.title = list[i].Title;
                e.id = list[i].Id;
                if (list[i].IsPast === true) {
                    e.className = "oldevent";
                }
                this.calendarEventList.push(e);
            }
        },
        renderEvents: function () {
            $('#calview').fullCalendar('destroy');
            $('#calview').fullCalendar({
                theme: true,
                defaultView: 'month',
                firstDay: 1,
                aspectRatio: 2.0,
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                editable: false,

                eventClick: function (calEvent, jsEvent, view) {
                    var eventItem = XViewer.Calendar.getEvent(calEvent.id);
                    XViewer.displayEvent(eventItem);
                }
            });
            $('#calview').fullCalendar('addEventSource', this.calendarEventList);
        },
        getEvent: function (eventId) {
            var len = this.eventList.length;
            for (var i = 0; i < len; i++) {
                if (this.eventList[i].Id === eventId) {
                    return this.eventList[i];
                }
            }
        }
    },

    Contact: {
        tmpl_person: '<li data-pid="[ID]"><div><span class="listinfo-title">[NAME]</span><br><span class="listinfo-small">[EMAIL]<br>[MOBILE]    [DESK]<span></div></li>',
        contactList: [],
        init: function () {
            //buttons events vs
            //this.getList();
        },
        getList: function () {
            XViewer.ajaxCall("XchangeViewer/Home", "GetContactList", {},
                function (resp) {
                    if (resp && resp.ok === true) {
                        XViewer.Contact.displayList(resp.ContactList);
                    }
                    else {
                        XViewer.error(resp.message);
                    }
                }
            );
        },
        displayList: function (list) {
            this.contactList = list;
            var len = list.length;

            $('#contact-person-list').html('');
            var html = "";
            for (var i = 0; i < len; i++) {
                var e = list[i];
                html += this.tmpl_person.replace("[NAME]", e.DisplayName).replace("[EMAIL]", e.Email).replace("[MOBILE]", e.MobilePhone).replace("[DESK]", e.DeskPhone).replace("[ID]", e.Id);
            }
            $('#contact-person-list').html(html);

            $('#contact-person-list li').on('click', function () {
                $("#contact-person-list div").removeClass('selected');
                $(this).children("div").addClass('selected');
            });
        }
    },

    MeetingRequest: {
        send: function () {
            var meeting = {};
            meeting.Title = "test mr 3";
            meeting.Description = "test mr body from xchange";
            meeting.Start = "11-24-2012 11:00";
            meeting.End = "11-24-2012 13:00";
            meeting.Location = "denizin sehpasi";
            meeting.Invited = ["deniz.test@cronom.com"];

            XViewer.ajaxCall("XchangeViewer/Home", "SendMeeting", meeting,
                function (resp) {
                    if (resp && resp.ok === true) {
                        //XViewer.Contact.displayList(resp.ContactList);
                        XViewer.alert("Meeting sent.");
                        XViewer.Calendar.init();
                    }
                    else {
                        XViewer.error(resp.message);
                    }
                }
            );
        },
        accept: function (eventId) {
            var meeting = { 'id': eventId };
            XViewer.ajaxCall("XchangeViewer/Home", "ApproveMeeting", meeting,
                function (resp) {
                    if (resp && resp.ok === true) {
                        XViewer.alert("Meeting accepted.");
                        XViewer.Calendar.init();
                    }
                    else {
                        XViewer.error(resp.message);
                    }
                }
            );
        },
        decline: function (eventId) { },
    },

    ajaxCall: function (controller, action, payload, _success) {
        var url = "http://" + window.location.host + "/" + controller + "/" + action;
        var options = {
            type: 'POST', url: url, traditional: true, success: _success,
            error: function (err) { XViewer.error(err.data); }
        };
        if (payload) {
            options.data = payload;
        }
        $.ajax(options);
    },
    alert: function (message) {
        apprise(message);
    },
    error: function (message) {
        this.alert('<b>Error<b><br><br>' + message);
    },
    confirm: function (message, callback) {
        apprise(message, { 'verify': true }, callback);
    },
    displayEventRequest: function (eventItem, callback) {
        var wrapper = '<div class="noselect apprise-event-detail"><span class="panel-header">' + eventItem.Title + '</span><br><br>' + eventItem.Description + '</div>';
        apprise(wrapper, { 'verify': true, 'textYes': 'Accept', 'textNo': 'Decline' }, callback);
    },
    displayEvent: function (eventItem) {
        var wrapper = '<div class="noselect apprise-event-detail"><span class="panel-header">' + eventItem.Title + '</span><br><br>' + eventItem.Description + '</div>';
        apprise(wrapper);
    },
    calculateDuration: function (varSeconds) {
        if ((varSeconds / 60) < 60) {
            return parseInt((varSeconds / 60)) + " minutes";
        }
        else if ((varSeconds / 3600) == 1) {
            return "1 hour";
        }
        else if ((varSeconds / 3600) > 1 && (varSeconds / 3600) < 24) {
            return parseInt((varSeconds / 3600)) + " hours";
        }
        else if ((varSeconds / (3600 * 24)) > 1 && (varSeconds / (3600 * 24)) < 30) {
            return parseInt((varSeconds / (3600 * 24))) + " days";
        }
    },

    _endobj: null
};