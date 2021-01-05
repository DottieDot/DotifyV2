import { Divider, List, ListItem, ListItemIcon, ListItemText, makeStyles, Typography } from '@material-ui/core'
import { 
  GitHub as GithubIcon,
} from '@material-ui/icons'
import React, { Fragment } from 'react'

const useStyles = makeStyles(theme => ({
  list: {
    marginLeft: -theme.spacing(2),
    marginRight: -theme.spacing(2),
  }
}))

export default () => {
  const classes = useStyles()

  return (
    <Fragment>
      <Typography
        variant="h6"
        component="h3"
      >
        Other
      </Typography>
      <Divider />
      <List className={classes.list}>
        <ListItem 
          component="a" 
          href="https://github.com/DottieDot/DotifyV2" 
          button
        >
          <ListItemIcon>
            <GithubIcon />
          </ListItemIcon>
          <ListItemText primary="Github Repository" />
        </ListItem>
      </List>
    </Fragment>
  )
}
