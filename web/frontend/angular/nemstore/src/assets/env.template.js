(function (window) {
	window["env"] = window["env"] || {};

	// Environment variables
  	window["env"]["Environment"] = "${Environment}";
	window["env"]["PodName"] = "${PodName}";
	window["env"]["PodNamespace"] = "${PodNamespace}";
	window["env"]["BffUrl"] = "${BffUrl}";
})(this);
