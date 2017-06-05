var _ServerRootUrl = "";

//Make initial FHIR call on page load
function OnPageLoad(ServerRootUrl) {
  $(document).ready(function () {
    _ServerRootUrl = ServerRootUrl;
    MakeFhirGetCall()    
  });
}

//Make Fhir call on button click
$(document).ready(function () {  
  $("#searchButton").click(function () {
    MakeFhirGetCall();
  });
});

function MakeFhirGetCall()
{
  //Get the user query string and append to service root url
  var FhirQuery = _ServerRootUrl + '/' + $('#queryString').val();

  //Make the JSON Call
  var JsonAcceptHeader = 'application/fhir+json';  
  var jsonrequest = xhr_get(FhirQuery, 'json', JsonAcceptHeader);

  jsonrequest.done(function (data, status, jqxhr) {
    httpStatusFormated('#fhirjsonStatus', status, jqxhr.status);
    $("#fhirjson").text(JSON.stringify(data, null, '  '));
    HighLightBlock();
  });

  jsonrequest.fail(function (jqxhr, status, error) {
    httpStatusFormated('#fhirjsonStatus', status, jqxhr.status);
    var d = jQuery.parseJSON(jqxhr.responseText);
    $("#fhirjson").text(JSON.stringify(d, null, '  '));
    HighLightBlock();
  });

  jsonrequest.always(function (data, status, jqxhr) {
    //Treat like finaly, clean up if needed.
    //$("#fhirjson").text("<p>An error has occurred: </p> <p>" + status + "</p>");        
  });
  
  //Make the XML Call
  var XmlAcceptHeader = 'application/fhir+xml';
  var xmlrequest = xhr_get(FhirQuery, 'xml', XmlAcceptHeader);
  
  xmlrequest.done(function (data, status, jqxhr) {
    httpStatusFormated('#fhirxmlStatus', status, jqxhr.status);
    $("#fhirxml").text(formatXml(jqxhr.responseText));
    HighLightBlock();
  });

  xmlrequest.fail(function (jqxhr, status, error) {
    httpStatusFormated('#fhirxmlStatus', status, jqxhr.status);
    $("#fhirxml").text(formatXml(jqxhr.responseText));
    HighLightBlock();
  });

  xmlrequest.always(function (data, status, jqxhr) {
    //Treat like finaly, clean up if needed.
    //$("#fhirjson").text("<p>An error has occurred: </p> <p>" + status + "</p>");        
  });

}


function httpStatusFormated(location, statusText, statusCode)
{
  return $(location).text("(" + statusCode + ") " + statusText);
}


function xhr_get(FhirQuery, DataType, AcceptHeader) {  
  return $.ajax({
    url: FhirQuery,
    type: 'get',
    headers: { 'Accept': AcceptHeader },
    dataType: DataType,
    cache: false
  })  
}

function HighLightBlock() {

  $('pre code').each(function (i, block) {
      hljs.highlightBlock(block);
  });  
}

function formatXml(xml) {
  var formatted = '';
  var reg = /(>)(<)(\/*)/g;
  xml = xml.replace(reg, '$1\r\n$2$3');
  var pad = 0;
  jQuery.each(xml.split('\r\n'), function (index, node) {
    var indent = 0;
    if (node.match(/.+<\/\w[^>]*>$/)) {
      indent = 0;
    } else if (node.match(/^<\/\w/)) {
      if (pad != 0) {
        pad -= 1;
      }
    } else if (node.match(/^<\w[^>]*[^\/]>.*$/)) {
      indent = 1;
    } else {
      indent = 0;
    }

    var padding = '';
    for (var i = 0; i < pad; i++) {
      padding += '  ';
    }

    formatted += padding + node + '\r\n';
    pad += indent;
  });

  return formatted;
}


$(document).ready(function () {

  var statesone = ['Patient', 'Observation', 'DiagnosticReport', 'Encounter', '$server-resource-report',
    '$server-indexes-delete-history-indexes'
  ];

  // constructs the suggestion engine
  var states = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.whitespace,
    queryTokenizer: Bloodhound.tokenizers.whitespace,
    // `states` is an array of state names defined in "The Basics"
    local: statesone
  });

  function extractor(query) {
    var result = /([^,]+)$/.exec(query);
    if (result && result[1])
      return result[1].trim();
    return '';
  }

  $('#bloodhound .typeahead').typeahead({
    hint: true,
    highlight: true,
    minLength: 1
  },
    {
      name: 'states',
      source: states,
      updater: function(item) {
        return this.$element.val().replace(/[^,]*$/, '') + item + ',';
      },
      matcher: function (item) {
        var tquery = extractor(this.query);
        if (!tquery) return false;
        return ~item.toLowerCase().indexOf(tquery.toLowerCase())
      },
      highlighter: function (item) {

        var query = extractor(this.query).replace(/[\-\[\]{}()*+?.,\\\^$|#\s]/g, '\\$&')
        return item.replace(new RegExp('(' + query + ')', 'ig'), function ($1, match) {
          return '<strong>' + match + '</strong>'
        })
      }

    });
});