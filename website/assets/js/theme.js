(function () {
  var GH_URL = 'https://github.com/binbashburns';
  var STORAGE_KEY = 'bbb-theme';
  var root = document.documentElement;

  function currentTheme() {
    return root.getAttribute('data-theme') === 'dark' ? 'dark' : 'light';
  }

  function applyTheme(theme) {
    if (theme === 'dark') {
      root.setAttribute('data-theme', 'dark');
    } else {
      root.removeAttribute('data-theme');
    }
  }

  function buildTopbar() {
    if (document.querySelector('.bbb-topbar')) return;

    var topbar = document.createElement('div');
    topbar.className = 'bbb-topbar';

    var ghLink = document.createElement('a');
    ghLink.href = GH_URL;
    ghLink.target = '_blank';
    ghLink.rel = 'noopener noreferrer';
    ghLink.title = 'GitHub';
    ghLink.setAttribute('aria-label', 'GitHub');
    ghLink.innerHTML =
      '<svg viewBox="0 0 16 16" width="18" height="18" fill="currentColor" aria-hidden="true">' +
      '<path d="M8 0C3.58 0 0 3.58 0 8c0 3.54 2.29 6.53 5.47 7.59.4.07.55-.17.55-.38 0-.19-.01-.82-.01-1.49-2.01.37-2.53-.49-2.69-.94-.09-.23-.48-.94-.82-1.13-.28-.15-.68-.52-.01-.53.63-.01 1.08.58 1.23.82.72 1.21 1.87.87 2.33.66.07-.52.28-.87.51-1.07-1.78-.2-3.64-.89-3.64-3.95 0-.87.31-1.59.82-2.15-.08-.2-.36-1.02.08-2.12 0 0 .67-.21 2.2.82.64-.18 1.32-.27 2-.27.68 0 1.36.09 2 .27 1.53-1.04 2.2-.82 2.2-.82.44 1.1.16 1.92.08 2.12.51.56.82 1.27.82 2.15 0 3.07-1.87 3.75-3.65 3.95.29.25.54.73.54 1.48 0 1.07-.01 1.93-.01 2.2 0 .21.15.46.55.38A8.012 8.012 0 0 0 16 8c0-4.42-3.58-8-8-8z"/>' +
      '</svg>';

    var btn = document.createElement('button');
    btn.type = 'button';
    btn.id = 'bbb-theme-toggle';
    btn.title = 'Toggle light / dark theme';
    btn.setAttribute('aria-label', 'Toggle theme');

    var icon = document.createElement('span');
    icon.className = 'bbb-theme-toggle-icon';
    icon.setAttribute('aria-hidden', 'true');
    icon.textContent = currentTheme() === 'dark' ? '☀' : '☾';
    btn.appendChild(icon);

    btn.addEventListener('click', function () {
      var next = currentTheme() === 'dark' ? 'light' : 'dark';
      applyTheme(next);
      try { localStorage.setItem(STORAGE_KEY, next); } catch (e) { /* ignore */ }
      icon.textContent = next === 'dark' ? '☀' : '☾';
    });

    topbar.appendChild(ghLink);
    topbar.appendChild(btn);
    document.body.appendChild(topbar);
  }

  if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', buildTopbar);
  } else {
    buildTopbar();
  }
})();
