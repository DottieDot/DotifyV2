import { Card, CardContent, CardMedia, Grid, makeStyles, Typography, Button, useTheme, useMediaQuery, Portal, IconButton, Menu, MenuItem } from '@material-ui/core'
import React, { MutableRefObject, ReactElement, useCallback, useState, MouseEvent } from 'react'
import AddPropsWhenScrolled from './AddPropsWhenScrolled'
import LikeButton from './LikeButton'
import { MediaTypes } from '../common'
import { MediaCover } from '.'
import { MoreVert as MoreVertIcon } from '@material-ui/icons'

const useStyles = makeStyles(theme => ({
  card: {
    position: 'sticky',
    top: 75,
    [theme.breakpoints.down('sm')]: {
      display: 'flex',
      flexDirection: 'row',
    }
  },
  cover: {
    background: theme.palette.primary.main,
    [theme.breakpoints.down('sm')]: {
      minWidth: 100,
      width: 100,
      height: '1fr',
    },
    [theme.breakpoints.up('md')]: {

    }
  },
  cardContent: {
    padding: '16px !important',
    [theme.breakpoints.down('sm')]: {
      flex: 1
    }
  },
  playButton: {
    marginBottom: theme.spacing(1)
  },
  buttons: {
    [theme.breakpoints.down('xs')]: {
      display: 'none'
    }
  },
  menuButton: {
    [theme.breakpoints.up('sm')]: {
      display: 'none'
    }
  },
  title: {
    textOverflow: 'ellipsis',
    whiteSpace: 'nowrap',
    overflow: 'hidden',
    [theme.breakpoints.up('sm')]: {
      marginRight: theme.spacing(1),
    }
  },
  subtitle: {
    textOverflow: 'ellipsis',
    whiteSpace: 'nowrap',
    overflow: 'hidden',
  },
  titleContainer: {
    display: 'grid',
    [theme.breakpoints.down('xs')]: {
      gridTemplateColumns: '1fr auto'
    },
    [theme.breakpoints.up('sm')]: {
      gridTemplateColumns: 'auto 1fr'
    }
  },
  titleControls: {
    whiteSpace: 'nowrap',
  }
}))

interface CommonProps {
  title: string
  subtitle?: ReactElement
  stickyContainer: MutableRefObject<null>
  type: MediaTypes,
  id: number
}

type ShareProps =
  | { shareable?: false, onShare?: never }
  | { shareable: true, onShare: () => void }

type PlayProps =
  | { playable?: false, onPlay?: never }
  | { playable: true, onPlay: () => void }

type Props = CommonProps & ShareProps & PlayProps

export default ({ title, subtitle, playable, onPlay, shareable, onShare, stickyContainer, type, id }: Props) => {
  const classes = useStyles()
  const theme = useTheme()
  const sticky = useMediaQuery(theme.breakpoints.down('sm'))
  const [menuAnchorEl, setMenuAnchorEl] = useState<HTMLElement | null>(null)

  const openMenu = useCallback((event: MouseEvent<HTMLButtonElement>) => {
    setMenuAnchorEl(event.currentTarget)
  }, [setMenuAnchorEl])

  const closeMenu = useCallback(() => {
    setMenuAnchorEl(null)
  }, [setMenuAnchorEl])

  const handlePlay = useCallback(() => {
    setMenuAnchorEl(null)
    onPlay && onPlay()
  }, [setMenuAnchorEl, onPlay])

  const handleShare = useCallback(() => {
    setMenuAnchorEl(null)
    onShare && onShare()
  }, [setMenuAnchorEl, onShare])

  const content = (
    <Card className={classes.card}>
      <CardMedia className={classes.cover}>
        <MediaCover
          name={title}
          coverArt={null}
          variant="flat"
          color="primary"
        />
      </CardMedia>
      <CardContent className={classes.cardContent}>
        <Grid container spacing={2}>
          <Grid item md={12} sm={8} xs={12}>
            <div className={classes.titleContainer}>
              <Typography className={classes.title} variant="h5" component="h1">
                {title}
              </Typography>
              <div className={classes.titleControls}>
                <LikeButton type={type} id={id} />
                <IconButton
                  size="small"
                  onClick={openMenu}
                  className={classes.menuButton}
                >
                  <MoreVertIcon />
                </IconButton>
              </div>
            </div>
            <Typography 
              className={classes.subtitle}
              variant="subtitle1" 
              color="textSecondary" 
              gutterBottom
            >
              {subtitle}
            </Typography>
          </Grid>
          <Grid className={classes.buttons} item xs>
            {playable && (
              <Button
                className={classes.playButton}
                variant="contained"
                color="primary"
                onClick={onPlay}
                fullWidth
              >
                Play
              </Button>
            )}
            {shareable && (
              <Button
                variant="outlined"
                onClick={onShare}
                fullWidth
              >
                Share
              </Button>
            )}
          </Grid>
        </Grid>
        <Menu
          open={!!menuAnchorEl}
          anchorEl={menuAnchorEl}
          onClose={closeMenu}
          keepMounted
        >
          {playable && (
            <MenuItem onClick={handlePlay}>Play</MenuItem>
          )}
          {shareable && (
            <MenuItem onClick={handleShare}>Share</MenuItem>
          )}
        </Menu>
      </CardContent>
    </Card>
  )

  if (sticky && stickyContainer.current) {
    return (
      <Portal container={stickyContainer.current}>
        <AddPropsWhenScrolled props={{ elevation: 4 }}>
          {content}
        </AddPropsWhenScrolled>
      </Portal>
    )
  }
  else {
    return content
  }
}
