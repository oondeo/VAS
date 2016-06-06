/*
 * Copyright (C) 2014 Andoni Morales <ylatuya@gmail.com>
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA 02110-1301, USA.
 *
 */
 
#ifndef HAVE_LGM_GTK_GLUE_H
#define HAVE_LGM_GTK_GLUE_H

#ifdef WIN32
#define EXPORT __declspec (dllexport)
#else
#define EXPORT
#endif

#include <gdk/gdk.h>

G_BEGIN_DECLS
EXPORT void lgm_gtk_glue_gdk_event_button_set_button (GdkEventButton *event, guint button);
G_END_DECLS

#endif