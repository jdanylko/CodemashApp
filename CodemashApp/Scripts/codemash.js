$(function() {
    var db = new PouchDB('codemashdb');

    var jumper = "";

    // Speakers
    function speakerClickEvent(e) {
        e.preventDefault();
        var url = $(e.currentTarget).attr("data-target");
        jumper = $(e.currentTarget).attr("name");

        function speakerDetailLoadCompleted() {
            $(".loading-status").fadeOut("fast", function() {
                $(".speaker-detail").fadeIn("fast");
            });
            $(".back-button").on("click", function(f) {
                f.preventDefault();
                $(".session-detail").fadeOut("fast", function() {
                    $(".panel-group").fadeIn("fast");
                    var item = $("[name='" + jumper + "']");
                    $(document).scrollTop(item.offset().top - 50);
                });
                $(".speaker-detail").fadeOut("fast", function() {
                    $(".speaker-list").fadeIn("fast");
                    var item = $("[name='" + jumper + "']");
                    $(document).scrollTop(item.offset().top - 50);
                });
            });
        }

        function speakerListFadedComplete() {
            $(".loading-status").fadeIn("fast", function() {
                $(".speaker-detail").load(url, speakerDetailLoadCompleted);
            });
        }

        $(".speaker-list").fadeOut("fast", speakerListFadedComplete);
    };

    $("a.speaker").on("click", speakerClickEvent);

    // Sessions
    function sessionClickEvent(e) {
        e.preventDefault();

        var url = $(e.currentTarget).attr("data-target");
        jumper = $(e.currentTarget).attr("name");

        function sessionDetailDisplayed() {
            var sessionDetail = $(".session-detail");
            var sessionInfo = $(".session-info");

            var initButton = $("button", sessionInfo);
            var id = $(sessionInfo).attr("data-id");
            db.get(id, {}, function(error, response) {
                if (error == null) {
                    $("i", initButton).addClass("fa-heart");
                } else {
                    if (error.status === 404) {
                        $("i", initButton).removeClass("fa-heart");
                    } else {
                        $("i", initButton).addClass("fa-heart");
                    }
                }
            });

            $(".back-button").on("click", function(f) {
                f.preventDefault();
                $(sessionDetail).fadeOut("fast", function() {
                    $(".panel-group").fadeIn("fast");
                    var item = $("[name='" + jumper + "']");
                    $(document).scrollTop(item.offset().top - 50);
                    db.get(jumper, {}, function(error, response) {
                        if (error == null) {
                            $(".favorite", item).show();
                        } else {
                            if (error.status === 404) {
                                $(".favorite", item).hide();
                            } else {
                                $(".favorite", item).show();
                            }
                        }
                    });

                });
            });

            $("button", sessionInfo).on("click", function(t) {
                t.preventDefault();
                var button = $(this);
                db.get(id, {}, function(error, doc) {
                    if (error) {
                        if (error.status === 404) {
                            // Add a new doc.
                            $("i", button).addClass("fa-heart");
                            $(sessionInfo).attr("data-selected", "true");
                            return db.put({
                                _id: id
                            });
                        } else {
                            // some other error.
                            console.write(error);
                        }
                        return false;
                    } else {
                        // Remove it.
                        return db.remove(doc, function() {
                            $("i", button).removeClass("fa-heart");
                            $(sessionDetail).attr("data-selected", "false");
                        });
                    }
                });
                return false;
            });
        }

        function sessionDetailLoadCompleted() {
            var sessionDetail = $(".session-detail");
            $(".loading-status").fadeOut("fast", function() {
                $(sessionDetail).fadeIn("fast", sessionDetailDisplayed);
            });
        };

        function panelGroupFadeOutComplete() {
            $(".loading-status").fadeIn("fast", function() {
                $(".session-detail").load(url, sessionDetailLoadCompleted);
            });
        }

        $(".panel-group").fadeOut("fast", panelGroupFadeOutComplete);
    }

    // determine if we are on the sessions page (either all or by day).
    if ($("a.session").size() > 0) {
        $("a.session").on("click", sessionClickEvent);

        db.allDocs().then(function(result) {
            var rows = result.rows;
            $(rows).each(function(index, elem) {
                if (!elem._deleted) {
                    $(".favorite", "a[name=" + elem.id + "]").show();
                }
            });
        });
    }

    // Agenda details.
    if ($(".agenda").size() > 0) {
        $(".agenda-select, .agenda-events").on("click", function () {
            var row = $(this).closest("tr");
            var element = $("i", $(".agenda-select", row));
            var agendaId = $(row).attr("data-id");
            // not checked.
            if ($(element).hasClass("fa-square-o")) {
                db.get(agendaId, {}, function(error, doc) {
                    if (error) {
                        if (error.status === 404) {
                            // Add a new doc.
                            element
                                .removeClass("fa-square-o")
                                .addClass("fa-check-square-o");
                            return db.put({
                                _id: agendaId
                            });
                        } else {
                            // some other error.
                            console.write(error);
                        }
                    }
                    return false;
                });
            } else {
                // Checked.
                db.get(agendaId, {}, function(error, doc) {
                    return db.remove(doc, function() {
                        element
                            .removeClass("fa-check-square-o")
                            .addClass("fa-square-o");
                    });
                });
            }
        });

        db.allDocs().then(function(result) {
            var rows = result.rows;
            $("tbody tr[data-id]").hide();
            $(rows).each(function (index, elem) {
                if (!elem._deleted) {
                    $("tbody tr[data-id="+elem.id+"]").show();
                }
            });
        });
    }
});