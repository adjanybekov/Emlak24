Auth
====

Source
~~~~~~

Sass source are in ``template_src/src/assets/sass/block/_auth.sass``

Jade source are in folder ``template_src/jade/partials/chunks/auth``

JS source are in ``template_src/src/assets/js/module/ui/auth-btn.js``


Variations
~~~~~~~~~~

*
  ``auth--login`` - register form

  .. image:: ../img/auth--login.png

  .. code-block:: html

      <div class="dropdown__menu auth__dropdown--login">
        <!-- BEGIN AUTH LOGIN-->
        <h5 class="auth__title">Login in your account</h5>
        <form action="#" class="auth__form js-login-form js-parsley">
          <div class="auth__row form-group">
            <label for="login-username-dropdown" class="auth__label control-label">Username</label>
            <input type="text" name="username" id="login-username-dropdown" required data-parsley-trigger="keyup" data-parsley-minlength="6" data-parsley-validation-threshold="5" data-parsley-minlength-message="Login should be at least 6 chars" class="auth__in auth__in--text form-control">
          </div>
          <div class="auth__row auth__row--password form-group">
            <label for="login-password-dropdown" class="auth__label control-label">Password</label>
            <input type="password" name="password" id="login-password-dropdown" required class="auth__in auth__in--text form-control">
          </div>
          <div class="auth__row">
            <button type="button" class="auth__forgot js-user-restore">Forgot password ?</button>
            <button type="submit" class="auth__in auth__in--submit">Sign in</button><span class="auth__remember">
              <input type="checkbox" id="remember-in-dropdown" class="in-checkbox">
              <label for="remember-in-dropdown" class="in-label">Remember me</label></span>
          </div>
          <div class="auth__row"><span class="auth__links">Not a user yet?
              <button type="button" class="js-user-register">Get an account</button></span></div>
        </form>
        <!-- end of block .auth__form-->
        <!-- END AUTH LOGIN-->
      </div>
*
  ``auth--register`` - register form

  .. image:: ../img/auth--register.png

  .. code-block:: html

      <div class="dropdown__menu auth__dropdown--register">
        <!-- BEGIN AUTH REGISTER-->
        <h5 class="auth__title">Sign up a new account</h5>
        <form action="#" class="auth__form js-register-form js-parsley">
          <div class="auth__coll form-group">
            <label for="register-name-dropdown" class="auth__label control-label">First name</label>
            <input type="text" name="username" id="register-name-dropdown" required class="auth__in auth__in--text form-control">
          </div>
          <div class="auth__coll auth__coll--right form-group">
            <label for="register-lastname-dropdown" class="auth__label control-label">Last name</label>
            <input type="text" name="name" id="register-lastname-dropdown" required class="auth__in auth__in--text form-control">
          </div>
          <div class="auth__coll auth__coll--email form-group">
            <label for="register-email-dropdown" class="auth__label control-label">E-mail</label>
            <input type="email" name="email" id="register-email-dropdown" required class="auth__in auth__in--text form-control">
          </div>
          <div class="auth__coll auth__coll--right form-group">
            <label for="register-password-dropdown" class="auth__label control-label">Password</label>
            <input type="password" name="password" id="register-password-dropdown" required class="auth__in auth__in--text form-control">
          </div>
          <div class="auth__row"><span class="auth__links">Back to
              <button type="button" class="js-user-login">Log In</button></span>
            <button type="submit" class="auth__in auth__in--submit">Sign up</button>
          </div>
        </form>
        <!-- end of block .auth__form-->
        <!-- END AUTH REGISTER-->
      </div>

*
  ``auth--restore`` - register form

  .. image:: ../img/auth--restore.png

  .. code-block:: html

    <div class="dropdown__menu auth__dropdown--restore">
      <!-- BEGIN AUTH RESTORE-->
      <h5 class="auth__title">Reset password</h5>
      <form action="#" class="auth__form js-restore-form js-parsley">
        <div class="auth__row form-group">
          <label for="restore-email-dropdown" class="auth__label control-label">Enter your User Name or Email</label>
          <input type="email" name="email" id="restore-email-dropdown" required class="auth__in auth__in--text form-control">
        </div>
        <div class="auth__row">
          <button type="submit" class="auth__in auth__in--submit">Reset password</button>
        </div>
        <div class="auth__row"><span class="auth__links">Back to
            <button type="button" class="js-user-login">Log In</button>or
            <button type="button" class="js-user-register">Registration</button></span>
          <!-- end of block .auth__links-->
        </div>
      </form>
      <!-- end of block .auth__form-->
      <!-- END AUTH RESTORE-->
    </div>

*
  ``auth--logged-in`` - register form

  .. image:: ../img/auth--loggedin.png

  .. code-block:: html

      <li class="dropdown auth__nav-item">
        <button data-toggle="dropdown" type="button" class="dropdown-toggle js-auth-nav-btn auth__nav-btn">
          <svg class="auth__icon-user">
            <use xlink:href="#icon-user"></use>
          </svg><span class="header__span"> Hi Jenifer</span>
        </button>
        <div class="dropdown__menu auth__dropdown--logged-in js-user-logged-in">
          <!-- BEGIN WORKER PROFILE-->
          <div class="worker worker--navbar">
            <div class="worker__item">
              <h3 class="worker__name">Jenniffer Hartnet</h3>
              <div class="worker__photo">
                <div class="worker__avatar">
                  <svg>
                    <use xlink:href="#icon-avatar"></use>
                  </svg>
                </div>
                <button class="worker__avatar-upload">Upload your profile picture</button>
              </div>
              <nav class="worker__nav">
                <ul>
                  <li><a href="my_listings.html">My listing</a></li>
                  <li><a href="my_profile.html">My Profile</a></li>
                  <li><a href="my_profile.html">Settings</a></li>
                </ul>
              </nav>
              <!-- end of block .worker__nav-->
            </div>
            <!-- end of block .worker__item-->
          </div>
          <!-- END WORKER PROFILE-->
        </div>
      </li>


*
  ``auth--inline`` - inline form, remove class ``dropdown-menu`` , add class ``auth--inline``

  .. image:: ../img/auth--inline.png

  .. code-block:: html

    <div class="auth auth--login auth--inline">


.. Note:: Pay attention to input's attributes ``data-parsley-*`` this are rules for validation, see documentation `Parsleyjs <http://parsleyjs.org/>`_
